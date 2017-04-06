using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectForWikExamples {
	class Person {
		public string Name { get; set; }
		public int Age { get; set; }
		public double Salary { get; set; }
	}
	class Employee {
		public string Name { get; set; }
		public string Job { get; set; }
	}
	class Job {
		public string JobCode { get; set; }
		public string Description { get; set; }
	}
	class Program {
		void Test() {
			Person[] persons = {
				new Person() { Name = "George", Age = 39, Salary = 42000.0 },
				new Person() { Name = "Janice", Age = 28, Salary = 27000.0 },
				new Person() { Name = "Luke", Age = 32, Salary = 31000.0 },
				new Person() { Name = "Alice", Age = 24, Salary = 37000.0 }
			};
			Employee[] employees = {
				new Employee() { Name = "Alan", Job = "Engineer" },
				new Employee() { Name = "Barb", Job = "Manager" },
				new Employee() { Name = "Charlie", Job = "Engineer" }
			};

			Job[] jobs = {
				new Job() { JobCode = "Manager", Description = "1st Level Manager" },
				new Job() { JobCode = "Engineer", Description = "Mechanical Engineer" }
			};
			var joined = from e in employees join j in jobs	on e.Job equals j.JobCode select new { e.Name, j.Description };
			//var sorted = from p in persons where p.Age > 19 && p.Age < 30 orderby p.Age descending select p;
			//var sorted = persons
			//			.Where(p => p.Age > 19 && p.Age < 30)
			//			.OrderByDescending(p => p.Age);
			//var selected = from p in persons
			//				   select new { p.Salary, p.Name };
		}
		static void Main(string[] args) {
			new Program().Test();
		}
		void Run() {
			StackEnhanced<long> ints = new StackEnhanced<long>();
			ints.Push(5);
			ints.Push(4, 3, 2, 1);
			ints.Push(0, -1, -2, -3, -4);
			ints.Push(-5);
			while(ints.Count() > 0) {
				var i = ints.Pop();
				Console.Write("{0} ", i);
			}
			Console.WriteLine();
			Console.ReadKey();
		}
	}
	public class StackEnhanced<T> {

		class ObjectLinkedList {
			public T _object;
			public ObjectLinkedList _next;
		}
		static ObjectLinkedList Empty = null;
		ObjectLinkedList top = Empty;

		public int Count() {
			if (top == null)
				return 0;
			var count = 0;
			var obj = top;
			while(obj != null) {
				count++;
				obj = obj._next;
			}
			return count;
		}
		public void Push(T t) {
			ObjectLinkedList ll = new ObjectLinkedList() { _object = t, _next = Empty };
			if (top == null) {
				top = ll;
			} else {
				ll._next = top;
				top = ll;
			}
			return;
		}
		public void Push(params T[] ts) {
			foreach (T t in ts) {
				this.Push(t);
			}
		}
		public T Pop() {
			if (top == null)
				return default(T);
			ObjectLinkedList curr = top;
			top = (ObjectLinkedList)curr._next;
			return (T)curr._object;
		}
		public StackEnhanced() {
		}
	}
}
