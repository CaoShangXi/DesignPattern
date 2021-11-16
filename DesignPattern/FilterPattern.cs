using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 过滤器模式
/// </summary>
namespace DesignPattern.FilterPattern
{
    /// <summary>
    /// 人
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        /// <summary>
        /// 性别
        /// </summary>
        private string gender;
        /// <summary>
        /// 婚姻状态
        /// </summary>
        private string maritalStatus;

        public Person(string name, string gender, string maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }

        public string GetName()
        {
            return name;
        }
        public string GetGender()
        {
            return gender;
        }
        public string GetMaritalStatus()
        {
            return maritalStatus;
        }
    }

    /// <summary>
    /// 标准接口
    /// </summary>
    public interface ICriteria
    {
        /// <summary>
        /// 符合标准
        /// </summary>
        /// <param name="persons">人</param>
        /// <returns></returns>
        List<Person> MeetCriteria(List<Person> persons);
    }

    /// <summary>
    /// 男性标准
    /// </summary>
    public class CriteriaMale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.GetGender().Equals("MALE", StringComparison.CurrentCultureIgnoreCase))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }

    /// <summary>
    /// 女性标准
    /// </summary>
    public class CriteriaFemale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.GetGender().Equals("FEMALE", StringComparison.CurrentCultureIgnoreCase))
                {
                    femalePersons.Add(person);
                }
            }
            return femalePersons;
        }
    }

    /// <summary>
    /// 单身标准
    /// </summary>
    public class CriteriaSingle : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.GetMaritalStatus().Equals("SINGLE", StringComparison.CurrentCultureIgnoreCase))
                {
                    singlePersons.Add(person);
                }
            }
            return singlePersons;
        }
    }

    /// <summary>
    /// AND标准
    /// </summary>
    public class AndCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;
        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.MeetCriteria(persons);
            return otherCriteria.MeetCriteria(firstCriteriaPersons);
        }
    }

    /// <summary>
    /// OR标准
    /// </summary>
    public class OrCriteria:ICriteria
    {
   private ICriteria criteria;
    private ICriteria otherCriteria;
    public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
    {
        this.criteria = criteria;
        this.otherCriteria = otherCriteria;
    }
   public List<Person> MeetCriteria(List<Person> persons)
    {
        List<Person> firstCriteriaItems = criteria.MeetCriteria(persons);
        List<Person> otherCriteriaItems = otherCriteria.MeetCriteria(persons);

        foreach (Person person in otherCriteriaItems)
        {
            if (!firstCriteriaItems.Contains(person))
            {
                firstCriteriaItems.Add(person);
            }
        }
        return firstCriteriaItems;
    }
}
}
