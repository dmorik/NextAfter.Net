# NextAfter.Net

Calculations are often written in C++, the rounding of which must be controlled. The method `_controlfp` is usually used for this (https://learn.microsoft.com/en-us/cpp/c-runtime-library/reference/control87-controlfp-control87-2?view=msvc-170).

However, due to cross-platform, such a solution in `C#` is not available. You can work around this limitation by doing a calculation that, according to the `IEEE-754` standard, will round to the nearest neighbor, and then manually rounding the result up or down as needed.

In C++ there is a group of methods called `std:nextafter` and `std:nexttoward` (https://en.cppreference.com/w/cpp/numeric/math/nextafter).

There is no such thing in .Net Framework. So I decided to write a utility that will allow you to do this. I use this utility in my scientific work because I study interval analysis and I need to use outward rounding in calculations.

The utility guarantees the following behavior:
1. with any rounding direction, `NaN` will not change
2. with any rounding direction `+Inf` and `-Inf` will not change
3. when receiving the following representable numbers
 after `double.MaxValue` and `float.MaxValue` will be returned `+Inf`
4. when getting previous representable numbers
 before `double.MinValue` and `float.MinValue` will be returned `-Inf`
5. when receiving the following representable numbers
 after `0` it will return `float.Epsilon` and `double.Epsilon` respectively
6. when getting previous representable numbers
 before `0` will return `-float.Epsilon` and `-double.Epsilon` respectively
7. in other cases, when receiving the next number representable in floating-point arithmetic, a number that is strictly greater than the specified one will be returned, when receiving the previous number — strictly less, respectively (it is also guaranteed that between the original number and the result of the utility's calculations there are no other numbers representable in floating point arithmetic)
