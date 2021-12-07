using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// MVC模式
/// </summary>
namespace DesignPattern.MVCPattern
{
    /// <summary>
    /// 模型类，负责存储数据
    /// </summary>
    public class Student
    {
        private string rollNo;
        private string name;
        public string GetRollNo()
        {
            return rollNo;
        }
        public void SetRollNo(string rollNo)
        {
            this.rollNo = rollNo;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
    }

    /// <summary>
    /// 视图类，负责呈现数据
    /// </summary>
    public class StudentView
    {
        public void PrintStudentDetails(string studentName, string studentRollNo)
        {
            Console.WriteLine("Student: ");
            Console.WriteLine("Name: " + studentName);
            Console.WriteLine("Roll No: " + studentRollNo);
        }
    }

    /// <summary>
    /// 控制器作用于模型和视图上。它控制数据流向模型对象，并在数据变化时更新视图。它使视图与模型分离开。
    /// </summary>
    public class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void SetStudentName(string name)
        {
            model.SetName(name);
        }

        public string GetStudentName()
        {
            return model.GetName();
        }

        public void SetStudentRollNo(string rollNo)
        {
            model.SetRollNo(rollNo);
        }

        public string GetStudentRollNo()
        {
            return model.GetRollNo();
        }

        public void UpdateView()
        {
            view.PrintStudentDetails(model.GetName(), model.GetRollNo());
        }
    }
}
