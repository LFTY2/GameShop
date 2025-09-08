namespace Project
{
    public class SpriteAssetKeys
    {
        public static string CoinSprite => MakeSpriteString("Gold_Coin");
        public static string InventorySprite => MakeSpriteString("Inventory");
        private static string MakeSpriteString(string str)
        {
            return $"<sprite name={str}>";
        }
    }
}