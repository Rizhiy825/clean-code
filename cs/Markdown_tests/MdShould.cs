using Markdown;
using Microsoft.VisualBasic;
using FluentAssertions;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace Markdown_tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(@"�����, _���������� � ���� ������_ ���������� ��������� ��������", @"�����, <em>���������� � ���� ������</em> ���������� ��������� ��������", TestName = "{m}_Italic")]
        [TestCase(@"������ __�������� ��������� _���������_ ����__ ��������.",@"������ <strong>�������� ��������� <em>���������</em> ����</strong> ��������.", TestName = "{m}_InnerItalic")]
        [TestCase(@"������ __�������� ��������� _�������_�� ����__ ��������.",@"������ <strong>�������� ��������� <em>�������</em>�� ����</strong> ��������.", TestName = "{m}_InnerItalicInOneWordOnBoard")]
        [TestCase(@"������ __�������� ��������� ��_�����_�� ����__ ��������.",@"������ <strong>�������� ��������� ��<em>�����</em>�� ����</strong> ��������.", TestName = "{m}_InnerItalicInOneWord")]
        [TestCase(@"�� �� �������� � ������ _���������� __�������__ ��_ ��������.",@"�� �� �������� � ������ <em>���������� __�������__ ��</em> ��������.", TestName = "{m}_InnerBold")]
        [TestCase(@"__���������� �����__ ������ ����� \<strong>.", @"<strong>���������� �����</strong> ������ ����� \<strong>.", TestName = "{m}_Bold")]
        [TestCase(@"����� ������ ����� ������������, ����� �� �� �������� ������ ��������. \_��� ���\_, �� ������ ���������� ����� \<em>.",@"����� ������ ����� ������������, ����� �� �� �������� ������ ��������. _��� ���_, �� ������ ���������� ����� \<em>.", TestName = "{m}_ShieldingSlash")]
        [TestCase(@"������ ������������� �������� �� ����������, ������ ���� ���������� ���-��. ����� ���\���� �������������\ \������ ��������.\",@"������ ������������� �������� �� ����������, ������ ���� ���������� ���-��. ����� ���\���� �������������\ \������ ��������.\", TestName = "{m}_NonShieldingSlash")]
        [TestCase(@"������ ������������� ���� ����� ������������: \\_��� ��� ����� �������� �����_ \<em>",@"������ ������������� ���� ����� ������������: \<em>��� ��� ����� �������� �����</em> \<em>", TestName = "{m}_SlashShieldingSlash")]
        [TestCase(@"\\\_��� ��� �� ����� �������� �����_",@"\_��� ��� �� ����� �������� �����_", TestName = "{m}_TripleSlash")]
        [TestCase(@"�������� ������ ������ c �������_12_3 �� ��������� ���������� � ������ ���������� ��������� ��������.",@"�������� ������ ������ c �������_12_3 �� ��������� ���������� � ������ ���������� ��������� ��������.", TestName = "{m}_ConcatinationWithDigits")]
        [TestCase(@"������ �������� ����� ����� ��� �����: � � _���_���, � � ���_���_��, � � ���_��._",@"������ �������� ����� ����� ��� �����: � � <em>���</em>���, � � ���<em>���</em>��, � � ���<em>��.</em>", TestName = "{m}_ItalicInSameWord")]
        [TestCase(@"� �� �� ����� ��������� � ��_���� ��_���� �� ��������.",@"� �� �� ����� ��������� � ��_���� ��_���� �� ��������.", TestName = "{m}_ItalicInDifferentWord")]
        [TestCase(@"������ _������� �� ������� ������������ �������, ��_������� �����_��������� � ������� ������������_",@"������ <em>������� �� ������� ������������ �������, ��_������� �����_��������� � ������� ������������</em>", TestName = "{m}_ItalicDifferentWordsAndRightWrap")]
        [TestCase(@"�� ���������� ������ ��������� ������������ ������. ����� ���_ ��������_ �� ���������",@"�� ���������� ������ ��������� ������������ ������. ����� ���_ ��������_ �� ���������", TestName = "{m}_WhiteSpaceAfterOpeningModifier")]
        [TestCase(@"��� _�������� _�� ��������� ���������� ���������",@"��� _�������� _�� ��������� ���������� ���������", TestName = "{m}_ModifierAfterSpace")]
        [TestCase(@"� ������ __����������� _�������__ � ���������_ ��������� �� ���� �� ��� �� ��������� ����������.",@"� ������ __����������� _�������__ � ���������_ ��������� �� ���� �� ��� �� ��������� ����������.", TestName = "{m}_OverlapModifiers")]
        [TestCase(@"���� ������ Bold-������������� ������ ������ ____, �� ��� �������� ��������� ��������.",@"���� ������ Bold-������������� ������ ������ ____, �� ��� �������� ��������� ��������.", TestName = "{m}_NoSymbolsBetweenTwoBoldMods")]
        [TestCase(@"���� ������ Italic-������������� ������ ������ __, �� ��� �������� ��������� ��������.",@"���� ������ Italic-������������� ������ ������ __, �� ��� �������� ��������� ��������.", TestName = "{m}_NoSymbolsBetweenTwoItalicMods")]
        [TestCase(@"# ���� ����� ������ ��������������� � <h1> ���� ����� ������ ��������������� � </h1>",@"<h1> ���� ����� ������ ��������������� � <h1> ���� ����� ������ ��������������� � </h1></h1>", TestName = "{m}_Title")]
        [TestCase(@"# ��������� __� _�������_ ���������__",@"<h1> ��������� <strong>� <em>�������</em> ���������</strong></h1>", TestName = "{m}_TitleWithModifiers")]
        public void Md_CommonInput_ShouldBeExpected(string md, string exp)
        {
            var markdown = new Md();

            var html = markdown.Render(md);

            html.Should().Be(exp);
        }

        [TestCase(@"", @"", TestName = "EmptyInput")]
        [TestCase(@"  ", @"  ", TestName = "OnlyWhitespacesInput")]
        [TestCase(@"_", @"_", TestName = "OnlyItalic")]
        [TestCase(@"__", @"__", TestName = "OnlyBold")]
        public void Md_BorderlineCases_ShouldBeExpected(string md, string exp)
        {
            var markdown = new Md();

            var html = markdown.Render(md);

            html.Should().Be(exp);
        }

        [Test]
        public void Md_Performance_ShouldBeLinear()
        {
            var markdown = new Md();
            var line = @"_�������_ __�����__ \_�������\_ ������ �������";
            long lastTime = 0;

            for (int i = 1; i < 10; i++)
            {
                var testLine = string.Concat(Enumerable.Repeat(line, i));

                var sw = new Stopwatch();
                sw.Start();

                var html = markdown.Render(testLine);

                sw.Stop();

                if (i == 1) lastTime = sw.ElapsedTicks;
                else
                {
                    var currentTime = sw.ElapsedTicks;
                    var dif = currentTime - lastTime;

                    dif.Should().BeLessThan(currentTime);
                }
            }
        }
    }
}