using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CritterLines
{
    public static string[,] wormLines = new string[,]
    {
        {
            "Wow, look at you! You can almost stretch as long as me!",
            "Are you headed to the top? I heard there's good worm food up there.",
            "Lots of plants, lots of dirt. Worm paradise!",
            "Or, so I heard anyway. Tell me when you get back, ok?",
        },
        {
            "Did you know that worms are excellent gardeners?",
            "This flower was allll me.",
            "And the human that waters it.",
            "See ya up there, catto!",
        }
    };

    public static string[,] pidgeLines = new string[,]
    {
        {
            "Oh, hello! I'm Pigeon Lindbergh III but you can call me Pidge.",
            "You got up this high all by yourself? For a small cat, you are amazing!",
            "I'm actually afraid of heights. And this is as high as I like to be.",
        },
        {
            "Hi, it's Pidge again here!",
            "Oh? You also hate heights but hate giving up more? You're so inspiring!",
            "I need to try harder as well. Next time you see me hopefully I can be a little braver.",
        }
    };
    public static string[,] doreenLines = new string[,]
    {
        {
            "Sigh, I love this view of the city. If only it didn't smell like tuna.",
            "Oh! Hi little kitty.",
            "You sure are stretchy, aren't ya? What are you doing up here?",
            "...",
            "Ah, so there IS tuna. Well, thanks for taking care of it for me.",
        },
        {
            "Back so soon?",
            "You didn't fall down, did you?",
            "Poor baby. You look a little scruffed, but I'm glad you're ok.",
            "Don't be discourage, ok? You're the stretchiest cat I've ever seen.",
            "You'll get that tuna in no time at all.",
        }
    };
    public static string[,] squirrelLines = new string[,]
    {
        {
            "*squeak squeak* Ahh! Don't eat me!",
            "No, wait, I have a better idea! There's way better food on the roof!",
            "Like, premo tuna stuff. Way tastier than me!",
            "Oh, you're not gonna eat me? Huh.",
            "..still, if you see any cats around redirect them to the tuna.",
        },
        {
            "There's not a lot of trees around here. At least, not with acorns.",
            "I'm, uh.... I think I'm lost.",
            "This is the only acorn I've found all week. And fall's almost over, too!",
            "I heard there's a lot of acorns on the roof. Or at least a good view of the trees.",
            "If you get up there first, can you tell me where the park is?",
        }
    };
    public static string[,] catbroLines = new string[,]
    {
        {
            "Hey, I've never seen you around before. What brings you to these parts?",
            "I didn't know cats were supposed to stretch like that. You must have a good yoga instructor.",
            "You better not be trying to score the tuna up there. Those are all mine, I just haven't bothered to get to them yet.",
        },
        {
            "No point in trying so hard. I could beat to it if I wanted to.",
            "I'm just still enjoying the breeze a little bit more.",
            "Then you would have no chance.",
        }
    };

    public static int catbroCount = 0;
    public static int wormCount = 0;

    public static int squirrelCount = 0;
    public static int doreenCount = 0;
    public static int pidgeCount = 0;
}
