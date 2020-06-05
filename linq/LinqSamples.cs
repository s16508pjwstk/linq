using System;
using System.Collections.Generic;
using System.Text;

namespace linq
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "IT",
                Loc = "Moscow"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Management",
                Loc = "Paris"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "Salaries",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "John Doe",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Fullstack Java developer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Karolina Tkacz",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "acquisition partner",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Kowalski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Łukasz Wielgo",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Fullstack programmer",
                Mgr = e2,
                Salary = 6500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Zuzia Pikuła",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Andrzej Janusz",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager Supervisor",
                Mgr = null,
                Salary = 10000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Lachowicz",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "DB administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Krajwski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile app developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CEO",
                Mgr = null,
                Salary = 15000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Network administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Example1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select emp;
            Console.WriteLine("#1.1\t" + String.Join(", ", res.Select(x => x.ToString())));

            //2. Lambda and Extension methods
            var res2 = Emps.Where(emp => emp.Job == "Backend programmer")
                .Select(emp => emp);
            Console.WriteLine("#1.2\t" + String.Join(", ", res2.Select(x => x.ToString())));
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            var res = Emps.Where(emp => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                .OrderByDescending(emp => emp.Ename)
                .Select(emp => emp);
            Console.WriteLine("#2\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            var res = Emps.Max(emp => emp.Salary);
            Console.WriteLine("#3\t" + res);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            var res = Emps.Where(emp => emp.Salary == Emps.Max(emp => emp.Salary))
                .Select(emp => emp);
            Console.WriteLine("#4\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            var res = Emps.Select(emp => new
            {
                Nazwisko = emp.Ename,
                Praca = emp.Job
            });
            Console.WriteLine("#5\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            var res = Emps
                .Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
                {
                    emp,
                    dept
                })
                .Select(x => new
                {
                    x.emp.Ename,
                    x.emp.Job,
                    x.dept.Dname
                });
            Console.WriteLine("#6\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            var res = Emps.GroupBy(emp => emp.Job)
                .Select(emp => new
                {
                    Praca = emp.Key,
                    LiczbaPracownikow = emp.Count()
                });
            Console.WriteLine("#7\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            var res = Emps.Any(emp => emp.Job == "Backend programmer");
            Console.WriteLine("#8\t" + res);
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            var res = Emps.Where(emp => emp.Job == "Frontend programmer")
                .OrderByDescending(emp => emp.HireDate)
                .Take(1);
            Console.WriteLine("#9\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10()
        {
            var res = Emps
                .Select(emp => new
                {
                    emp.Ename,
                    emp.Job,
                    emp.HireDate
                })
                .Union(new[]
                {
                    new
                    {
                        Ename = "Brak wartości",
                        Job = (string) null,
                        HireDate = (Nullable<DateTime>) null
                    }
                });
            Console.WriteLine("#10\t" + String.Join(", ", res.Select(x => x.ToString())));
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            var res = Emps.Aggregate((current, next) => current.Salary > next.Salary ? current : next);
            Console.WriteLine("#11\t" + res.ToString());
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            var res = Emps.SelectMany(emp => Depts, (emp, dept) => new
            {
                Emp = emp,
                Dept = dept
            });
            Console.WriteLine("#12\t" + String.Join(", ", res.Select(x => x.ToString())));
        }
    }
}
