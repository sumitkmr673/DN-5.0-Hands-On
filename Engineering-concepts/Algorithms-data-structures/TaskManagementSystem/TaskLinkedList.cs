using System;

namespace TaskManagementSystem
{
    public class Task
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public Task? Next { get; set; }

        public Task(string id, string name, string status)
        {
            TaskId = id;
            TaskName = name;
            Status = status;
            Next = null;
        }
    }

    public class LinkedListManager
    {
        private Task? _head;

        public void AddTask(Task newTask)
        {
            if (_head == null)
            {
                _head = newTask;
                Console.WriteLine($"[Added] ID: {newTask.TaskId} | Name: {newTask.TaskName}");
                return;
            }

            Task current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newTask;
            Console.WriteLine($"[Added] ID: {newTask.TaskId} | Name: {newTask.TaskName}");
        }

        public Task? SearchTask(string id)
        {
            Task? current = _head;

            while (current != null)
            {
                if (current.TaskId == id)
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }

        public void TraverseTasks()
        {
            if (_head == null)
            {
                Console.WriteLine("[Warning] No tasks found in the system.");
                return;
            }

            Task? current = _head;
            while (current != null)
            {
                Console.WriteLine($"[Task Record] ID: {current.TaskId} | Name: {current.TaskName} | Status: {current.Status}");
                current = current.Next;
            }
        }

        public void DeleteTask(string id)
        {
            if (_head == null)
            {
                Console.WriteLine($"[Error] Cannot delete. The task list is empty.");
                return;
            }

            if (_head.TaskId == id)
            {
                string deletedName = _head.TaskName;
                _head = _head.Next;
                Console.WriteLine($"[Deleted] Successfully removed Task {id}: {deletedName}");
                return;
            }

            Task current = _head;
            while (current.Next != null && current.Next.TaskId != id)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                string deletedName = current.Next.TaskName;
                current.Next = current.Next.Next;
                Console.WriteLine($"[Deleted] Successfully removed Task {id}: {deletedName}");
            }
            else
            {
                Console.WriteLine($"[Error] Task ID {id} not found.");
            }
        }
    }
}