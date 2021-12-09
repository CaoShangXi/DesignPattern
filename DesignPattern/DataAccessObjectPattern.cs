using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 数据访问对象模式
/// </summary>
namespace DesignPattern.DataAccessObjectPattern
{
    public class Student
    {
        private string name;
        private int rollNo;

        public Student(string name, int rollNo)
        {
            this.name = name;
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

        public int GetRollNo()
        {
            return rollNo;
        }

        public void SetRollNo(int rollNo)
        {
            this.rollNo = rollNo;
        }
    }

    /// <summary>
    /// 数据访问接口
    /// </summary>
    public interface IStudentDao
    {
        List<Student> GetAllStudents();
        Student GetStudent(int rollNo);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }

    public class StudentDaoImpl:IStudentDao
    {
        //列表是当作一个数据库
        List<Student> students;
   public StudentDaoImpl()
    {
        students = new List<Student>();
        Student student1 = new Student("Robert", 0);
        Student student2 = new Student("John", 1);
        students.Add(student1);
        students.Add(student2);
    }
   public void DeleteStudent(Student student)
    {
        students.Remove(student);
        Console.WriteLine("Student: Roll No " + student.GetRollNo()
           + ", deleted from database");
    }

    //从数据库中检索学生名单
   public List<Student> GetAllStudents()
    {
        return students;
    }

   public Student GetStudent(int rollNo)
    {
        return students.First(x => x.GetRollNo().Equals(rollNo));
    }

   public void UpdateStudent(Student student)
    {
        students[student.GetRollNo()].SetName(student.GetName());
        Console.WriteLine("Student: Roll No " + student.GetRollNo()
           + ", updated in the database");
    }
}
}
