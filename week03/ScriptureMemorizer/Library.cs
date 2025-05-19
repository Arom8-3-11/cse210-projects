using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;

public class Library
{
    private List<Scripture> _scriptures;
    private Random _rand;

    public Library()
    {
        _scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "\n\nFor God so loved the world that he gave his only begotten Son,\n that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Doctrine and Covenants", 46, 32),
                "\n\nAnd ye must gibe thanks unto God in the Spirit for whatsoever blessing ye are blessed with."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5),
                "\n\nTrust in the Lord with all thine heart; and lean not unto thine own understanding."
            ),
            new Scripture(
                new Reference("Alma", 13, 27, 29),
                "\n\n27 And now, my brethern I wish from the inmost part of my hear, \nyea, with great anxiety even unto pain, \nthat ye would hearken unto my words, and cast off your sins, \nand not procrastinate the day of your repentance; \n\n28 But that ye would humble yourselves before the Lord, \nand call on his holy name, and watch and pray continually, \nthat ye may not be tempted above that which ye can bear, \nand thus be led by the Holy Spirit, becoming humble, meek, submissive, patient, \nfull of love and all long-suffering; \n\n29 Having faith on the Lord; having a hope that ye shall receive eternal life;\n having the love of God always in your hearts, \nthat ye may be lifted up at the last day and enter into his rest."
            ),
            new Scripture(
                new Reference("Luke", 1, 37),
                "\n\nFor with God nothing shall be impossible"
            ),
            new Scripture(
                new Reference("Doctrine and Covenants", 58, 42, 43),
                "\n\n42 Behold, he who has repented of his sins, the same is forgiven, \nand I, the Lord, remember them no more. \n\n43 By this ye may know if a man repenteth of his sins—behold, \nhe will confess them and forsake them."
            ),
            new Scripture(
                new Reference("Romans", 14, 13),
                "\n\nLet us not therefore judge one another any more: but judge this rather, \nthat no man put a stumblingblock or an occasion to fall in his brother's way."
            ),
            new Scripture(
                new Reference("Doctrine and Covenants", 43, 32),
                "\n\nAnd he that liveth in righteousness shall be changed \nin the twinkling of and eye, and the earth shall pass away so as by fire."
            ),
            new Scripture(
                new Reference("Doctrine and Covenants", 42, 62),
                "\n\nThou shalt ask, and it shall be revealed unto you in \nmine own due time where the New Jerusalem shall be built."
            ),
            new Scripture(
                new Reference("3 Nephi", 21, 7),
                "\n\nAnd when these things come to pass that thy seed shall begin\n to know these things-it shall be a sign unto them, \nthat they may know that the work of the Father hath already \ncommenced unto the fulfilling of the covenant \nwhich he hath made unto the people who are of the house of Israel."
            ),
            new Scripture(
                new Reference("Alma", 5, 14),
                "\n\nAnd now behold, I ask of you, my brethren of the chuch, \nhave ye spiritually been born of God? have ye received his image in your countenances? \nHave ye experienced this mighty change in your hearts?"
            ),
            new Scripture(
                new Reference("3 Nephi", 11, 11),
                "\n\nAnd behold, I am the light and the life of the world; \nand I have drunk out of that bitter cup which the Father hath given me, \nand have glorified the Father in taking upon me the sins of the world, \nin the which I have suffered the will of the Father in all things from the beginning."
            ),
            new Scripture(
                new Reference("1 Nephi", 3, 7),
                "\n\nAnd it came to pass that I, Nephi, said unto my father: \nI will go and do the things which the Lord hat commanded, \nfor I know that the Lord giveth no commandments unto the children of men, \nsave he shall prepare a way for them that they may \naccomplish the thing which he commandeth them."
            )
        };
        _rand = new Random();
    }

    public Scripture GetRandomScripture()
    {
        int idx = _rand.Next(_scriptures.Count);
        return _scriptures[idx];
    }
}