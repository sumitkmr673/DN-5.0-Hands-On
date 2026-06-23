using System;

namespace TaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Dynamic Task Management System ---\n");

            LinkedListManager taskList = new LinkedListManager();

            taskList.AddTask(new Task("TSK001", "Integrate UPI Payment Gateway", "In Progress"));
            taskList.AddTask(new Task("TSK002", "Fix Aadhaar KYC Validation Bug", "Pending"));
            taskList.AddTask(new Task("TSK003", "Deploy GST Invoice Module", "Completed"));

            Console.WriteLine("\nExecuting Traversal:");
            taskList.TraverseTasks();

            Console.WriteLine("\nExecuting Search for Target ID: TSK002...");
            Task? foundTask = taskList.SearchTask("TSK002");
            if (foundTask != null)
            {
                Console.WriteLine($"[Search Match] Found Task: {foundTask.TaskName} (Status: {foundTask.Status})");
            }

            Console.WriteLine("\nExecuting Deletion for Target ID: TSK002...");
            taskList.DeleteTask("TSK002");

            Console.WriteLine("\nExecuting Traversal After Deletion:");
            taskList.TraverseTasks();
        }
    }
}