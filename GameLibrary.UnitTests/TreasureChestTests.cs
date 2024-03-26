using Xunit.Abstractions;

namespace GameLibrary.UnitTests;

public class TreasureChestTests : IDisposable
{
    private readonly Stack<TreasureChest> chests;
    private readonly ITestOutputHelper output;

    public TreasureChestTests(ITestOutputHelper output)
    {
        // verify that constructor is called before every test
        chests = new();
        this.output = output;
        output.WriteLine($"Initial chest count: {chests.Count}");
    }

    [Theory]
    [InlineData(true, true, true)]
    [InlineData(true, false, false)]
    [InlineData(false, true, true)]
    [InlineData(false, false, true)]
    public void CanOpen_WhenCalled_ReturnsExpectedOutput(bool isLocked, bool hasKey, bool expected)
    {
        // arrange
        var sut = new TreasureChest(isLocked);
        chests.Push(sut);
        output.WriteLine($"Chest count: {chests.Count}");

        // act
        var actual = sut.CanOpen(hasKey);

        // assert
        Assert.Equal(expected, actual);
        Assert.Single(chests);
    }

    [Fact(Skip = "Covered by theory test")]
    public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
    {
        // arrange
        var sut = new TreasureChest(true);
        chests.Push(sut);
        output.WriteLine($"Chest count: {chests.Count}");

        // act
        var result = sut.CanOpen(true);

        // assert
        Assert.True(result);
        Assert.Single(chests);
    }

    [Fact]
    public void CanOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
    {
        // arrange
        var sut = new TreasureChest(true);
        chests.Push(sut);
        output.WriteLine($"Chest count: {chests.Count}");

        // act
        var result = sut.CanOpen(false);

        // assert
        Assert.False(result);
        Assert.Single(chests);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasKey_ReturnsTrue()
    {
        // arrange
        var sut = new TreasureChest(false);
        chests.Push(sut);
        output.WriteLine($"Chest count: {chests.Count}");

        // act
        var result = sut.CanOpen(true);

        // assert
        Assert.True(result);
        Assert.Single(chests);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasNoKey_ReturnsTrue()
    {
        // arrange
        var sut = new TreasureChest(false);
        chests.Push(sut);
        output.WriteLine($"Chest count: {chests.Count}");

        // act
        var result = sut.CanOpen(false);

        // assert
        Assert.True(result);
        Assert.Single(chests);
    }

    public void Dispose()
    {
        chests.Pop();
        Assert.Empty(chests);
        output.WriteLine($"Final chest count: {chests.Count}");
    }
}