namespace GameLibrary.UnitTests;

public class TreasureChestTests
{
    [Fact]
    public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
    {
        // arrange
        var sut = new TreasureChest(true);

        // act
        var result = sut.CanOpen(true);

        // assert
        Assert.True(result);
    }

    [Fact]
    public void CanOpen_ChestIsLockedAndHasNoKey_ReturnsFalse()
    {
        // arrange
        var sut = new TreasureChest(true);

        // act
        var result = sut.CanOpen(false);

        // assert
        Assert.False(result);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasKey_ReturnsTrue()
    {
        // arrange
        var sut = new TreasureChest(false);

        // act
        var result = sut.CanOpen(true);

        // assert
        Assert.True(result);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasNoKey_ReturnsTrue()
    {
        // arrange
        var sut = new TreasureChest(false);

        // act
        var result = sut.CanOpen(false);

        // assert
        Assert.True(result);
    }
}