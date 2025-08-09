namespace CraftingStation.Components.Grid.Data {
    public class InheritanceTestChild : InheritanceTest {

        protected override void OnBarcodeScanned(SomeBarcode value) {
            
        }

        protected override void OnBarcodeScanned(OtherBarcode value) {

        }
    }
}
