﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JapaneseCrossword.CrosswordSolvers
{
    [TestFixture]
    public class BackTrackingSolverTests
    {
        private BackTrackingSolver solver;

        [TestFixtureSetUp]
        public void SetUp()
        {
            solver = new BackTrackingSolver();
        }

        [Test]
        public void InputFileNotFound()
        {
            var solutionStatus = solver.Solve(Path.GetRandomFileName(), Path.GetRandomFileName());
            Assert.AreEqual(SolutionStatus.BadInputFilePath, solutionStatus);
        }

        [Test]
        public void IncorrectOutputFile()
        {
            var inputFilePath = @"TestFiles\SampleInput.txt";
            var outputFilePath = "///.&*#";
            var solutionStatus = solver.Solve(inputFilePath, outputFilePath);
            Assert.AreEqual(SolutionStatus.BadOutputFilePath, solutionStatus);
        }

        [Test]
        public void IncorrectCrossword()
        {
            var inputFilePath = @"TestFiles\IncorrectCrossword.txt";
            var outputFilePath = Path.GetRandomFileName();
            var solutionStatus = solver.Solve(inputFilePath, outputFilePath);
            Assert.AreEqual(SolutionStatus.IncorrectCrossword, solutionStatus);
            File.Delete(outputFilePath);
        }

        [Test]
        public void Simplest()
        {
            var inputFilePath = @"TestFiles\SampleInput.txt";
            var outputFilePath = Path.GetRandomFileName();
            var correctOutputFilePath = @"TestFiles\SampleInput.solved.txt";
            var solutionStatus = solver.Solve(inputFilePath, outputFilePath);
            Assert.AreEqual(SolutionStatus.Solved, solutionStatus);
            CollectionAssert.AreEqual(File.ReadAllText(correctOutputFilePath), File.ReadAllText(outputFilePath));
            File.Delete(outputFilePath);
        }

        [Test]
        public void Car()
        {
            var inputFilePath = @"TestFiles\Car.txt";
            var outputFilePath = Path.GetRandomFileName();
            var correctOutputFilePath = @"TestFiles\Car.solved.txt";
            var solutionStatus = solver.Solve(inputFilePath, outputFilePath);
            Assert.AreEqual(SolutionStatus.Solved, solutionStatus);
            CollectionAssert.AreEqual(File.ReadAllText(correctOutputFilePath), File.ReadAllText(outputFilePath));
            File.Delete(outputFilePath);
        }

        [Test]
        public void Flower()
        {
            var inputFilePath = @"TestFiles\Flower.txt";
            var outputFilePath = Path.GetRandomFileName();
            var correctOutputFilePath = @"TestFiles\Flower.solved.txt";
            var solutionStatus = solver.Solve(inputFilePath, outputFilePath);
            Assert.AreEqual(SolutionStatus.Solved, solutionStatus);
            CollectionAssert.AreEqual(File.ReadAllText(correctOutputFilePath), File.ReadAllText(outputFilePath));
            File.Delete(outputFilePath);
        }

        [Test]
        public void Winter()
        {
            var inputFilePath = @"TestFiles\Winter.txt";
            var outputFilePath = Path.GetRandomFileName();
            var correctOutputFilePath = @"TestFiles\Winter.fullSolved.txt";
            var solutionStatus = solver.Solve(inputFilePath, outputFilePath);
            Assert.AreEqual(SolutionStatus.Solved, solutionStatus);
            CollectionAssert.AreEqual(File.ReadAllText(correctOutputFilePath), File.ReadAllText(outputFilePath));
            File.Delete(outputFilePath);
        }
    }
}
