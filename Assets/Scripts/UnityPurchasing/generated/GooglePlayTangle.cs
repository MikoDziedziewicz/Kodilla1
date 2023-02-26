// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("W9rStDxc7Jkxeo6K1Y7InRqwkWdZveHylKBMAOPQvgV9pu5mdPbdH2Yr3DS+mjbWeHIWJ9IEN230ZJ3gqSokKxupKiEpqSoqK677Obm7t9escPfiSttirxzgD04JesDqkbvV3B8rhU+FusAqFcna4YpHsm2PVfMNhyEY3xJ0nk8mL0fRaEYgWdkNvn/LyOHeUYLK4l4KXy8ujN/9liQNGRupKgkbJi0iAa1jrdwmKioqLisoDQe0P8hnRs7LF7REmNt2xWog9APABqVSzFj8UcFcpb03adUTMyy1pQWDxG3eZLR41Fsbq4zE+Y4W/rXCkfJ2x88ZmqeNrtXzu5bZaw2kV/ZEJy1djFdYsI+CD9xyqFG0yhCWIRmc2ZEwR3PZrikoKisq");
        private static int[] order = new int[] { 12,11,8,11,10,7,9,13,12,12,13,13,12,13,14 };
        private static int key = 43;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
