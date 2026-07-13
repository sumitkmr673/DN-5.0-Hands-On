using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaChatApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();

            // Start the background listener task immediately
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => StartKafkaConsumer(_cancellationTokenSource.Token));
        }

        // THE PRODUCER (SEND BUTTON)
        private async void button2_Click(object sender, EventArgs e)
        {
            // 1. Read from the smaller box (Input Box)
            string messageText = txtMessageInput.Text;
            if (string.IsNullOrWhiteSpace(messageText)) return;

            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    // 2. Publish to Kafka
                    await producer.ProduceAsync("chat-message", new Message<Null, string> { Value = messageText });

                    // 3. Clear the Input Box
                    txtMessageInput.Clear();
                }
                catch (ProduceException<Null, string> ex)
                {
                    MessageBox.Show($"Delivery failed: {ex.Error.Reason}");
                }
            }
        }

        // CANCEL BUTTON

        private void button1_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            this.Close();
        }

        // THE CONSUMER (BACKGROUND LISTENER)

        private void StartKafkaConsumer(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "chat-windows-client",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("chat-message");

                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var consumeResult = consumer.Consume(cancellationToken);
                        if (consumeResult != null)
                        {
                            // Pushes new messages to the history tracker
                            UpdateChatHistory(consumeResult.Message.Value);
                        }
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    consumer.Close();
                }
            }
        }

        // UI THREAD SAFETY HELPER
        private void UpdateChatHistory(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateChatHistory), new object[] { message });
                return;
            }

            // Appends messages dynamically into the History box
            txtMessages.AppendText("User: " + message + Environment.NewLine);
        }

        private void txtMessages_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtMessageInput_TextChanged(object sender, EventArgs e) { }
    }
}
