# Xyaneon.Games.Dice

[![License](https://img.shields.io/github/license/Xyaneon/Xyaneon.Games.Dice)][License]
[![NuGet](https://img.shields.io/nuget/v/Xyaneon.Games.Dice.svg?style=flat)][NuGet package]
[![Build and test](https://github.com/Xyaneon/Xyaneon.Games.Dice/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Xyaneon/Xyaneon.Games.Dice/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/Xyaneon/Xyaneon.Games.Dice/badge.svg?branch=main)](https://coveralls.io/github/Xyaneon/Xyaneon.Games.Dice?branch=main)
[![semantic-release: conventionalcommits](https://img.shields.io/badge/semantic--release-conventionalcommits-e10079?logo=semantic-release)](https://github.com/semantic-release/semantic-release)

![Package Icon][icon]

A .NET Standard 2.0 library for dice, including standard and custom dice.

## Usage

### Setup

To use this library, you must first install the [NuGet package][NuGet package]
for it, then add the following `using` statement at the top of each C# source
file where you plan on using it:

```csharp
using Xyaneon.Games.Dice;
```

### Rolling standard dice

#### Single rolls

This library provides several built-in classes representing standard dice,
including:

- D4
- D6
- D8
- D10
- D12
- D20

These each inherit from `Dice<int>`. You can just call them with an empty
constructor to start using them right away. An optional `seed` integer can
also be passed into a die's constructor if you want a repeatable pseudorandom
sequence of rolled values.

After creation, you can simply call the `Roll` method to get a random result:

```csharp
var die = new D6();

int rollResult = die.Roll(); // Can be 1, 2, 3, 4, 5 or 6.
```

#### Multiple rolls

To avoid having to call `Roll` multiple times, you can also supply an integer
indicating how many rolls you want, then get the results as an
`IEnumerable<int>`:

```csharp
var die = new D20();

// Sample returned sequence: [6, 18, 4, 20, 1]
IEnumerable<int> rollResult = die.Roll(5);
```

### Flipping coins

This library also provides a `Coin` class, which is considered to be a
two-sided die. Flips are returned as `CoinFlipResult` enum values:

```csharp
var coin = new Coin();

// Could return CoinFlipResult.Heads or CoinFlipResult.Tails.
CoinFlipResult flipResult = coin.Flip();
```

### Custom dice

You are not restricted to standard number dice. The `Die<TFace>` base class is
generic and can be instantiated using a custom collection of your choice
representing the die's faces.

```csharp
var colorDie = new Die<Color>(new Color[] {
    Color.Red,
    Color.Blue,
    Color.Yellow,
    Color.Green
});

Color rollResult = die.Roll();
```

## License

This library is free and open-source software provided under the MIT license.
Please see the [LICENSE.txt][License] file for details.

[icon]: https://github.com/Xyaneon/Xyaneon.Games.Dice/blob/main/Xyaneon.Games.Dice/images/icon.png
[License]: https://github.com/Xyaneon/Xyaneon.Games.Dice/blob/main/LICENSE.txt
[NuGet package]: https://www.nuget.org/packages/Xyaneon.Games.Dice/
