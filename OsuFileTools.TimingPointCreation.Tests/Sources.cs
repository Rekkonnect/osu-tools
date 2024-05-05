﻿namespace OsuFileTools.TimingPointCreation.Tests;

public static class Sources
{
    public static class Polyrhythms
    {
        public const string Tpazolite_ChaosInTheDark = """
            Timing 54652 - 165 - 4/4

            // 2
            4:3/8
            2/16
            2/8 - 2 2 1
            2/8

            // 3
            4:3/8
            2/16
            3:2/16
            2/16
            1/4

            // 4
            5:3/8
            3:2/16
            5:3/8
            3:2/16

            // 5
            7:4/8 - 1 1 2 2 1 1 2 2 2 2
            1/2 - R

            // 6
            // source says 8:9/16
            8:10/16
            2/16
            4/16

            // 7
            5:3/8
            4:3/8
            1/4 - R

            // 8
            // source says 4:5/8 - 1 1 1 1 instead of 4:5/16 - 1. 1. 1
            // from audio wave image: 3 3/4 + 3 3/4 + 2 2/4
            // 15/4 + 15/4 + 10/4
            // 3 + 3 + 2
            // I don't make the rules
            2/8 - 1 2 2
            1/8
            4:5/16 - 1. 1. 1
            8:5/16

            // 9
            7:4/8 - 1 1 2 2 1 1 2 2 2 2
            1/2 - R

            // 10
            19:16/16

            // 11
            11:8/16
            1/2 - R

            // 12
            5:3/8
            3:2/16
            5:3/8
            3:2/16

            // 13
            7:4/8 - 1 1 2 2 1 1 2 2 2 2
            1/2 - R

            // 14
            5:3/8
            2/16
            2/8 - 2 2 1
            2/8

            // 15
            5:3/8
            2/16
            3:2/16
            2/16
            1/4

            // 16
            7:6/16 - 1/2 1 1 1 1 1
            3:2/16
            3/16
            8:5/16

            // 17
            7:4/8 - 1 1 2 2 1 1 2 2 2 2
            1/8 - R
            3/8 - 1. 1.

            // 18
            1/1
            
            """;
    }
}
