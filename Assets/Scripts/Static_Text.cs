

public static class Static_Text {

	public static string[] birdnames =new string[]{"Pink", "Blue", "Robin", "Owl", "Penguin", "Chicken", "Pig", "Canary", "Goat"};
	public static int[] birdcaught = new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0}; 
	public static string[] flavortext = new string[] {
		"this be the default birb.  it pink and precious!!  these are manyful, but they're all special. every single one.  if u think " +
		"u are a default birb, ur special!  just like each of these! <3", 
		"this be the social media birb!! it love people and it very extrovert. it also like activism and bird rights and it fight you" +
		" using strong words and logic. this birb go tweet tweet all day!", 
		"this be the birb wonder. birb wonder be adopted by mammal father and fight crime!  sometimes birb wonder also steal from the " +
		"rich and donate to the poor while shooting bow and arrow.", 
		"hoot hoot is asshole birb.  it hoot all nite and refuse 2 let you sleep.  also it have glowy eyes at nite and can be a teenybit" +
		" scary.  it lucky it so cute in daytime!", 
		"this birb likes cold and winter and play ice hockey. ice hockey far superior to field hockey.  ice hockey not quite as good as" +
		" air hockey, but penguin no can fly outside of video game.  ice glidey sport almost as fun!", 
		"this birb named cluck; is very onamatopoeic!  it love literature and poetry. cluck's favourite book be chicken little. cluck " +
		"think chicken little very inspiring!", 
		"this birb a SONGBIRB.  not a baby cluck!  (this birb also a straight up recolour of default pink birb; game artist got lazy.)", 
		"this birb be named football. football is totallyl a birb!! certainly not the physical manifestation of a popular idiom.  " +
		"how dare u accuse football of being notbirb?!", 
		"...this not birb!  what it do here??? well, you catched goatbirb. congrat, I guess? :O"};
	public static string mysteryBirbName = "mystery birb";
	public static string mysteryBirbText = "you have not almost catched this birb yet, silly!";
	public static int goatCaughtNum = 0;

	public static void resetGame() {
		for (int i = 0; i < birdcaught.Length; ++i) {
			birdcaught[i] = 0;
		}
		goatCaughtNum = 0;
	}
}
