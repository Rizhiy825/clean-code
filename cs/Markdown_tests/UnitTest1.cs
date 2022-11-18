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
        Parser parser = new Parser();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Italic()
        {
            var concs = parser.ParseMdToHTML(@"�����, _���������� � ���� ������_ ���������� ��������� ��������");
        }

        [Test]
        public void InnerItalic()
        {
            var concs = parser.ParseMdToHTML(@"������ __�������� ��������� _���������_ ����__ ��������.");
        }

        [Test]
        public void InnerItalicInOneWordOnBoard()
        {
            var concs = parser.ParseMdToHTML(@"������ __�������� ��������� _�������_�� ����__ ��������.");
        }

        [Test]
        public void InnerItalicInOneWord()
        {
            var concs = parser.ParseMdToHTML(@"������ __�������� ��������� ��_�����_�� ����__ ��������.");
        }

        [Test]
        public void InnerBold()
        {
            var concs = parser.ParseMdToHTML(@"�� �� �������� � ������ _���������� __�������__ ��_ ��������.");
        }


        [Test]
        public void Test2()
        {
            var concs = parser.ParseMdToHTML(@"__��������_ ������� � ������ ������ ������ �� _���������_ ����������.");

        }

        [Test]
        public void TestBold()
        {
            var concs = parser.ParseMdToHTML(@"__���������� ����� ��������� �����__ ������ ����������� ���������� � ������� ���� \<strong>.");

        }

        [Test]
        public void TesEscapeCharacter()
        {
            var concs = parser.ParseMdToHTML(@"����� ������ ����� ������������, ����� �� �� �������� ������ ��������. \_��� ���\_, �� ������ ���������� ����� \<em>.");
        }

        [Test]
        public void TesEscapeCharacter1()
        {
            var concs = parser.ParseMdToHTML(@"������ ������������� �������� �� ����������, ������ ���� ���������� ���-��. ����� ���\���� �������������\ \������ ��������.\");
        }

        [Test]
        public void TesEscapeCharacter2()
        {
            var concs = parser.ParseMdToHTML(@"������ ������������� ���� ����� ������������: \\_��� ��� ����� �������� �����_ \<em>");
        }

        [Test]
        public void TripleSlash()
        {
            var concs = parser.ParseMdToHTML(@"\\\_��� ��� �� ����� �������� �����_");
        }

        [Test]
        public void ConcatinationWithDigits()
        {
            var concs = parser.ParseMdToHTML(@"�������� ������ ������ c �������_12_3 �� ��������� ���������� � ������ ���������� ��������� ��������.");
        }

        [Test]
        public void PartOfWord()
        {
            var concs = parser.ParseMdToHTML(@"������ �������� ����� ����� ��� �����: � � _���_���, � � ���_���_��, � � ���_��._");
        }

        [Test]
        public void DifferentWords()
        {
            var concs = parser.ParseMdToHTML(@"� �� �� ����� ��������� � ��_���� ��_���� �� ��������.");
        }
        
        [Test]
        public void DifferentWordsAndRightWrap()
        {
            var concs = parser.ParseMdToHTML(@"������ _������� �� ������� ������������ �������, ��_������� �����_��������� � ������� ������������_");
        }

        [Test]
        public void NoChange()
        {
            var concs = parser.ParseMdToHTML(@"�� ����������, ����������� ���������, ������ ��������� ������������ ������. ����� ���_ ��������_ �� ��������� ���������� � �������� ������ ��������� ��������.");
        }

        [Test]
        public void ModifierAfterSpace()
        {
            var concs = parser.ParseMdToHTML(@"��������, ������������� ���������, ������ ��������� �� ������������ ��������. ����� ��� _�������� _�� ���������_ ���������� ��������� � �������� ������ ��������� ��������.");
        }

        [Test]
        public void OverlapModifiers()
        {
            var concs = parser.ParseMdToHTML(@"� ������ __����������� _�������__ � ���������_ ��������� �� ���� �� ��� �� ��������� ����������.");
        }

        [Test]
        public void NoSymbolsBetweenTwoBoldMods()
        {
            var concs = parser.ParseMdToHTML(@"���� ������ Bold-������������� ������ ������ ____, �� ��� �������� ��������� ��������.");
        }

        [Test]
        public void NoSymbolsBetweenTwoItalicMods()
        {
            var concs = parser.ParseMdToHTML(@"���� ������ Italic-������������� ������ ������ __, �� ��� �������� ��������� ��������.");
        }

        [Test]
        public void Title()
        {
            var concs = parser.ParseMdToHTML(@"# ���� ����� ������ ��������������� � <h1> ���� ����� ������ ��������������� � </h1>");
        }

        [Test]
        public void TitleWithModifiers()
        {
            var concs = parser.ParseMdToHTML(@"# ��������� __� _�������_ ���������__");
        }
    }
}