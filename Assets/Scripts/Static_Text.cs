

public class Static_Text {

	public  static string[] birdnames =new string[]{"Pink", "Blue", "Robin", "Chicken", "Owl", "Penguin", "Pig", "Canary", "Goat"};
	public  static int[] birdcaught = new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0}; 
	public  static string[] flavortext = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

	void Start () {
		
	} 

	public static void resetGame() {
		for (int i = 0; i < birdcaught.Length; ++i) {
			birdcaught[i] = 0;
		}
	}
}
