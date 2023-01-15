using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class Student
    {

        public Student(string name, string lastName, int age, int number, int speed)
        {
            name = name;
            lastName = lastName;
            age = age;
            number = number;
            speed = speed;
        }
        public string name { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public int number { get; set; }
        public int speed { get; set; }

        /*public static bool operator == (Student s1, Student s2) //STATIC OLMAK ZORUNDA!!! - nesneye ihtiyacı yok yani
        {
            return s1.lastName == s2.lastName;
        }

        public static bool operator != (Student s1, Student s2)
        {
            return s1.lastName != s2.lastName;
        }*/

        /*public static int operator +(Student s1, Student s2)

        {
            var result1 = s1.age / s1.speed;
            var result2 = s2.age / s2.speed;

            var result = result1 + result2;
            return result;

        }*/

        public static int operator +(Student s1, int y)

        { 

            var result = s1.age + y;
            return result;

        }
        public static Student operator +(Student s1, Student s2)

        {

            var sum = s1.age + s2.age;
            s1.age = sum;
            return s1;

        }

        /*public string bool operator true(bool x, bool y)
        {
            return true
        }*/ // GÖRÜLDÜĞÜ ÜZERE OLMUYOR !!!

        public static bool operator ==(Student s1, Student s2)
        {
            if (s1.name == s2.name && s1.lastName == s2.lastName && s1.age == s2.age && s1.speed == s2.speed) 
                return true;
            return false;

            // İÇERİĞİNİ KENDİME GÖRE DÜZENLEYEBİLİRİM. İSMİNİ BELİRTTİĞİMİZ TARZDA DOLDURMAK ZORUNDA DEĞİLİZ
            // == KULLANINCA İÇERİDE EŞİTLİĞE DAİR BİŞEY OLMAZSA HATA VERMEZ!!!
        }
        public static bool operator !=(Student s1, Student s2)
        {
            
            return s1.name == s2.name;
        }




    }
}
