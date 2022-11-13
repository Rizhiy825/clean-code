using NUnit.Framework;
using Markdown;
using Microsoft.VisualBasic;
using FluentAssertions;

namespace Markdown_tests
{
    [TestFixture]
    public class Tests
    {
        Md markdown = new Md();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var parser = new Parser("�����, _���������� � ���� ������_ ���������� ��������� ��������");
            var concs = parser.Parse();

            var expected = @"�����, \<em>���������� � ���� ������\</em> ���������� ��������� ��������,
������ ���������� � HTML-��� \<em>.";
            
        }

        [Test]
        public void Test2()
        {
            var parser = new Parser(@"__��������_ ������� � ������ ������ ������ �� ��������� ����������.");
            var concs = parser.Parse();

            

        }
    }
}