# NextAfter.Net

Calculations are often written in C++, the rounding of which must be controlled. The method `_controlfp` is usually used for this (https://learn.microsoft.com/en-us/cpp/c-runtime-library/reference/control87-controlfp-control87-2?view=msvc-170).

However, due to cross-platform, such a solution in `C#` is not available. You can work around this limitation by doing a calculation that, according to the `IEEE754` standard, will round to the nearest neighbor, and then manually rounding the result up or down as needed.

In C++ there is a group of methods called `std:nextafter` (https://en.cppreference.com/w/cpp/numeric/math/nextafter).

There is no such thing in .Net Framework. So I decided to write a utility that will allow you to do this. I use this utility in my scientific work because I study interval analysis and I need to use outward rounding in calculations.
