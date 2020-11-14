![alt text](imgs/lynx_logo_t.png)

Simple and easily extensible golfing language.

Contains two language interpratations. Concise and verbose.

# Example
This example shows a function printing the first 11 numbers of the Fibbonacci sequence.

## Concise interpretation
    0 1 0l10@L1c1c+

## Verbose interpretation
    0
    1
    0 WriteLine
    10 Repeat
        PeekWriteLine
        1 CopyToTop
        1 CopyToTop
        Add
    ;
