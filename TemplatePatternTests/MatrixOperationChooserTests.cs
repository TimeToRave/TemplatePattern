using System.Runtime.InteropServices;
using NUnit.Framework;
using TemplatePattern;

namespace TemplatePatternTests
{
    [TestFixture]
    public class MatrixOperationChooserTests
    {
        [Test]
        public void MatrixOperationChooser_Transponite()
        {
            var chooser = new MatrixOperationChooser();
            MatrixCalculator calculator = chooser.GetMatrixOperation("transponsite");
            
            Assert.IsInstanceOf(typeof(MatrixTranspositeCalculator), calculator);
        }
        
        [Test]
        public void MatrixOperationChooser_Determinant()
        {
            var chooser = new MatrixOperationChooser();
            MatrixCalculator calculator = chooser.GetMatrixOperation("determinant");
            
            Assert.IsInstanceOf(typeof(MatrixDeterminantCalculator), calculator);
        }
        
        [Test]
        public void MatrixOperationChooser_Summ()
        {
            var chooser = new MatrixOperationChooser();
            MatrixCalculator calculator = chooser.GetMatrixOperation("summ");
            
            Assert.IsInstanceOf(typeof(MatrixAdderCalculator), calculator);
        }
        
        [Test]
        public void MatrixOperationChooser_DefaultOperation()
        {
            var chooser = new MatrixOperationChooser();
            MatrixCalculator calculator = chooser.GetMatrixOperation("NotFound");
            
            Assert.IsInstanceOf(typeof(MatrixTranspositeCalculator), calculator);
        }
        
    }
}