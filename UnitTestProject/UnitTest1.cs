using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void TestMethod1() {
			TestProjectForWikExamples.StackEnhanced<int> ints = new TestProjectForWikExamples.StackEnhanced<int>();
			ints.Push(1);
			Assert.IsTrue(ints.Count() == 1);
			Assert.Inconclusive();
		}
	}
}
