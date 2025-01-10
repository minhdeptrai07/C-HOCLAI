namespace C__HOCLAI
{
        class Program
        {
            // Class Task
            public class Task
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public bool IsCompleted { get; set; }
            }

            // Class AdvancedTask kế thừa Task
            public class AdvancedTask : Task
            {
                public DateTime CreatedDate { get; set; }
                public DateTime UpdatedDate { get; set; }
                public string CreatedBy { get; set; }
            }

            // Danh sách công việc
            static List<Task> taskList = new List<Task>();
            static List<AdvancedTask> advancedTaskList = new List<AdvancedTask>();

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("\nTask Management System");
                    Console.WriteLine("1. Them cong viec");
                    Console.WriteLine("2. Sua cong viec");
                    Console.WriteLine("3. Xoa cong viec");
                    Console.WriteLine("4. Hien thi danh sach cong viec");
                    Console.WriteLine("5. Cap nhat trang thai cong viec");
                    Console.WriteLine("6. Thoat");

                    Console.Write("Chon chuc nang: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddTask();
                            break;
                        case "2":
                            EditTask();
                            break;
                        case "3":
                            DeleteTask();
                            break;
                        case "4":
                            DisplayTasks();
                            break;
                        case "5":
                            UpdateTaskStatus();
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Lua chon khong hop le . Hay thu lai.");
                            break;
                    }
                }
            }

            // Thêm công việc
            static void AddTask()
            {
                Console.Write("Nhap loai cong viec (1: Task, 2: AdvancedTask): ");
                string taskType = Console.ReadLine();

                Console.Write("Ten cong viec: ");
                string name = Console.ReadLine();

                Console.Write("Mo ta cong viec: ");
                string description = Console.ReadLine();

                if (taskType == "1") // Thêm Task
                {
                    int id = taskList.Count + 1;
                    taskList.Add(new Task
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        IsCompleted = false
                    });
                }
                else if (taskType == "2") // Thêm AdvancedTask
                {
                    Console.Write("Nguoi tao: ");
                    string createdBy = Console.ReadLine();

                    int id = advancedTaskList.Count + 1;
                    advancedTaskList.Add(new AdvancedTask
                    {
                        Id = id,
                        Name = name,
                        Description = description,
                        IsCompleted = false,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CreatedBy = createdBy
                    });
                }
                else
                {
                    Console.WriteLine("Loai cong viec khong hop le.");
                }
            }

            // Sửa công việc
            static void EditTask()
            {
                Console.Write("Nhao ID cong viec muon sua: ");
                int id = int.Parse(Console.ReadLine());

                var task = taskList.Find(t => t.Id == id);
                var advTask = advancedTaskList.Find(t => t.Id == id);

                if (task != null || advTask != null)
                {
                    Console.Write("Ten cong viec moi: ");
                    string name = Console.ReadLine();

                    Console.Write("Mo ta cong viec moi: ");
                    string description = Console.ReadLine();

                    if (task != null)
                    {
                        task.Name = name;
                        task.Description = description;
                    }

                    if (advTask != null)
                    {
                        advTask.Name = name;
                        advTask.Description = description;
                        advTask.UpdatedDate = DateTime.Now;
                    }
                }
                else
                {
                    Console.WriteLine("Khong tim thay cong viec voi ID nay.");
                }
            }

            // Xóa công việc
            static void DeleteTask()
            {
                Console.Write(" Nhap ID cong viec muon xoa: ");
                int id = int.Parse(Console.ReadLine());

                if (!taskList.RemoveAll(t => t.Id == id).Equals(0) ||
                    !advancedTaskList.RemoveAll(t => t.Id == id).Equals(0))
                {
                    Console.WriteLine("Da xoa thanh cong.");
                }
                else
                {
                    Console.WriteLine("Khong tim thay cong viec voi ID nay.");
                }
            }

            // Hiển thị danh sách công việc
            static void DisplayTasks()
            {
                Console.WriteLine("\nDanh sach Task:");
                foreach (var task in taskList)
                {
                    Console.WriteLine($"ID: {task.Id}, Ten: {task.Name}, Mo ta: {task.Description}, Trang thai: {(task.IsCompleted ? "Hoan thanh" : "Chua hoan thanh")}");
                }

                Console.WriteLine("\nDanh sach AdvancedTask:");
                foreach (var advTask in advancedTaskList)
                {
                    Console.WriteLine($"ID: {advTask.Id}, Ten: {advTask.Name}, Mo ta: {advTask.Description}, Trang thai: {(advTask.IsCompleted ? "Hoan thanh" : "Chua hoan thanh")}, Ngay tao: {advTask.CreatedDate}, Ngay cap nhat: {advTask.UpdatedDate}, Nguoi tao: {advTask.CreatedBy}");
                }
            }

            // Cập nhật trạng thái công việc
            static void UpdateTaskStatus()
            {
                Console.Write("Nhap ID cong viec muon cap nhat trang thai: ");
                int id = int.Parse(Console.ReadLine());

                var task = taskList.Find(t => t.Id == id);
                var advTask = advancedTaskList.Find(t => t.Id == id);

                if (task != null || advTask != null)
                {
                    Console.Write("Trang thai (1: Hoan thanh, 0: Chua hoan thanh): ");
                    bool isCompleted = Console.ReadLine() == "1";

                    if (task != null)
                    {
                        task.IsCompleted = isCompleted;
                    }

                    if (advTask != null)
                    {
                        advTask.IsCompleted = isCompleted;
                        advTask.UpdatedDate = DateTime.Now;
                    }

                    Console.WriteLine("Da cap nhat trang thai thanh cong.");
                }
                else
                {
                    Console.WriteLine("Khong tim thay cong viec voi ID nay.");
                }
            }
        }
    }