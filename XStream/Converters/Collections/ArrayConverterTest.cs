using NUnit.Framework;

namespace XStream.Converters.Collections {
    [TestFixture]
    public class ArrayConverterTest : CollectionConverterTestCase {
        [Test]
        public void ConvertsArray() {
            string serialisedArray =
                @"<System.Int32-array array-type=""System.Int32[]"">
    <System.Int32>10</System.Int32>
    <System.Int32>20</System.Int32>
    <System.Int32>30</System.Int32>
</System.Int32-array>";
            SerialiseAssertAndDeserialise(new int[] {10, 20, 30,}, serialisedArray);
        }

        [Test]
        public void FiguresOutRepeatingObjectsEvenThroughArrays() {
            AmbiguousReferenceHolder duplicateObject = new AmbiguousReferenceHolder(new Person("gl"));
            object[] objects = new object[] {"", duplicateObject, duplicateObject,};
            SerialiseAndDeserialise(objects);
            objects = (object[]) xstream.FromXml(xstream.ToXml(objects));
            Assert.AreSame(objects[1], objects[2]);
        }
    }
}