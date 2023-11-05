﻿using NUnit.Framework;
using System;

using System.Collections.Generic;

namespace TestApp.Tests;

public class DrumSetTests
{
    [Test]
    public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
    {
        //Arrange
        decimal myMoney = 100;
        List<int> list = new() { 2, 3, };
        List<string> commands = new() { "1", "1"};

        //Act + Assert
        Assert.That(() => DrumSet.Drum(myMoney, list, commands), Throws.ArgumentException);
    }

    [Test]
    public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
    {
        //Arrange
        decimal myMoney = 100;
        List<int> list = new() { 2, 3, };
        List<string> commands = new() { "1", "string", "Hit it again, Gabsy!" };

        //Act + Assert
        Assert.That(() => DrumSet.Drum(myMoney, list, commands), Throws.ArgumentException);
    }

    [Test]
    public void Test_Drum_ReturnsCorrectQualityAndAmount()
    {
        //Arrange
        decimal myMoney = 100;
        List<int> list = new() { 3, 4, };
        List<string> commands = new() { "1", "1", "Hit it again, Gabsy!" };

        string expected = "1 2\nGabsy has 100.00lv.";

        //Act
        string result = DrumSet.Drum(myMoney,list, commands);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount()
    {
        //Arrange
        decimal myMoney = 0;
        List<int> list = new() { 3, 4, 5};
        List<string> commands = new() { "2", "2", "Hit it again, Gabsy!" };

        string expected = "1\nGabsy has 0.00lv.";

        //Act
        string result = DrumSet.Drum(myMoney, list, commands);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount()
    {
        //Arrange
        decimal myMoney = 5;
        List<int> list = new() { 3, 4, 5 };
        List<string> commands = new() { "3", "3", "Hit it again, Gabsy!" };

        string expected = "\nGabsy has 5.00lv.";

        //Act
        string result = DrumSet.Drum(myMoney, list, commands);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
