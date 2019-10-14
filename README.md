MULTITHREADING HOMEWORK

RESULTS OF PERFORMANCE TESTS:

WithLock

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |      Mean |     Error |    StdDev |
|-------- |---------------- |---------------- |----------------- |--------- |----------:|----------:|----------:|
| Process |               1 |              10 |                3 |   Normal |  35.64 ms | 0.4531 ms | 0.4239 ms |
| Process |               1 |              10 |               10 |   Normal | 112.70 ms | 0.3555 ms | 0.3325 ms |
| Process |              10 |               1 |                3 |   Normal |  64.01 ms | 1.2740 ms | 2.5443 ms |
| Process |              10 |               1 |               10 |   Normal | 161.98 ms | 3.1925 ms | 7.8312 ms |
| Process |              10 |              10 |                3 |   Normal |  64.38 ms | 1.2872 ms | 2.5707 ms |
| Process |              10 |              10 |               10 |   Normal | 160.36 ms | 3.1912 ms | 4.9684 ms |
| Process |              10 |              10 |               10 | BelowNormal | 162.4 ms | 3.222 ms | 6.285 ms |
| Process |              10 |              10 |               10 | AboveNormal | 162.5 ms | 3.193 ms | 5.508 ms |

WithAutoReset

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |      Mean |     Error |    StdDev |
|-------- |---------------- |---------------- |----------------- |--------- |----------:|----------:|----------:|
| Process |               1 |              10 |                3 |   Normal | 20.026 ms | 0.2545 ms | 0.2381 ms |
| Process |               1 |              10 |               10 |   Normal | 19.793 ms | 0.2092 ms | 0.1747 ms |
| Process |              10 |               1 |                3 |   Normal |  4.821 ms | 0.0942 ms | 0.0881 ms |
| Process |              10 |               1 |               10 |   Normal |  6.475 ms | 0.1207 ms | 0.1129 ms |
| Process |              10 |              10 |                3 |   Normal | 21.773 ms | 0.2671 ms | 0.2499 ms |
| Process |              10 |              10 |               10 |   Normal | 23.472 ms | 0.2988 ms | 0.2649 ms |
| Process |              10 |              10 |               10 | BelowNormal | 4.976 ms | 0.0943 ms | 0.1009 ms |
| Process |              10 |              10 |               10 | AboveNormal | 5.116 ms | 0.0819 ms | 0.0684 ms |

WithManualReset (+lock)

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |     Mean |     Error |    StdDev |
|-------- |---------------- |---------------- |----------------- |--------- |---------:|----------:|----------:|
| Process |               1 |              10 |                3 |   Normal | 3.083 ms | 0.0546 ms | 0.0511 ms |
| Process |               1 |              10 |               10 |   Normal | 3.047 ms | 0.0511 ms | 0.0427 ms |
| Process |              10 |               1 |                3 |   Normal | 5.253 ms | 0.0961 ms | 0.1215 ms |
| Process |              10 |               1 |               10 |   Normal | 5.143 ms | 0.1006 ms | 0.1033 ms |
| Process |              10 |              10 |                3 |   Normal | 4.662 ms | 0.0924 ms | 0.1233 ms |
| Process |              10 |              10 |               10 |   Normal | 4.809 ms | 0.0958 ms | 0.2258 ms |
| Process |              10 |              10 |               10 | BelowNormal | 4.129 ms | 0.0837 ms | 0.1906 ms |
| Process |              10 |              10 |               10 | AboveNormal | 4.033 ms | 0.0346 ms | 0.0307 ms |

WithManualResetSlim (+lock)

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |     Mean |     Error |    StdDev |   Median |
|-------- |---------------- |---------------- |----------------- |--------- |---------:|----------:|----------:|---------:|
| Process |               1 |              10 |                3 |   Normal | 3.078 ms | 0.0584 ms | 0.0518 ms | 3.056 ms |
| Process |               1 |              10 |               10 |   Normal | 3.033 ms | 0.0232 ms | 0.0194 ms | 3.025 ms |
| Process |              10 |               1 |                3 |   Normal | 5.260 ms | 0.1039 ms | 0.1423 ms | 5.243 ms |
| Process |              10 |               1 |               10 |   Normal | 5.077 ms | 0.0943 ms | 0.0883 ms | 5.083 ms |
| Process |              10 |              10 |                3 |   Normal | 4.518 ms | 0.1038 ms | 0.2995 ms | 4.433 ms |
| Process |              10 |              10 |               10 |   Normal | 4.486 ms | 0.0893 ms | 0.2070 ms | 4.427 ms |
| Process |              10 |              10 |               10 | BelowNormal | 3.370 ms | 0.0669 ms | 0.0822 ms |
| Process |              10 |              10 |               10 | AboveNormal | 3.367 ms | 0.0212 ms | 0.0166 ms |

WithSemaphore

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |     Mean |     Error |    StdDev |   Median |
|-------- |---------------- |---------------- |----------------- |--------- |---------:|----------:|----------:|---------:|
| Process |               1 |              10 |                3 |   Normal | 2.498 ms | 0.0473 ms | 0.0563 ms | 2.489 ms |
| Process |               1 |              10 |               10 |   Normal | 2.562 ms | 0.0506 ms | 0.1045 ms | 2.522 ms |
| Process |              10 |               1 |                3 |   Normal | 3.012 ms | 0.0374 ms | 0.0350 ms | 3.013 ms |
| Process |              10 |               1 |               10 |   Normal | 3.152 ms | 0.0497 ms | 0.0465 ms | 3.155 ms |
| Process |              10 |              10 |                3 |   Normal | 3.758 ms | 0.0748 ms | 0.1595 ms | 3.704 ms |
| Process |              10 |              10 |               10 |   Normal | 5.145 ms | 0.0790 ms | 0.0739 ms | 5.108 ms |
| Process |              10 |              10 |               10 | BelowNormal | 5.093 ms | 0.0182 ms | 0.0162 ms |
| Process |              10 |              10 |               10 | AboveNormal | 5.159 ms | 0.1016 ms | 0.1285 ms |

WithSemaphoreSlim

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |     Mean |     Error |    StdDev |   Median |
|-------- |---------------- |---------------- |----------------- |--------- |---------:|----------:|----------:|---------:|
| Process |               1 |              10 |                3 |   Normal | 2.213 ms | 0.0308 ms | 0.0288 ms | 2.215 ms |
| Process |               1 |              10 |               10 |   Normal | 2.329 ms | 0.0603 ms | 0.1767 ms | 2.256 ms |
| Process |              10 |               1 |                3 |   Normal | 3.039 ms | 0.0088 ms | 0.0082 ms | 3.040 ms |
| Process |              10 |               1 |               10 |   Normal | 3.045 ms | 0.0081 ms | 0.0076 ms | 3.043 ms |
| Process |              10 |              10 |                3 |   Normal | 3.385 ms | 0.0491 ms | 0.0410 ms | 3.380 ms |
| Process |              10 |              10 |               10 |   Normal | 3.413 ms | 0.0579 ms | 0.0484 ms | 3.394 ms |
| Process |              10 |              10 |               10 | BelowNormal | 3.477 ms | 0.0719 ms | 0.2003 ms | 3.382 ms |
| Process |              10 |              10 |               10 | AboveNormal | 3.384 ms | 0.0366 ms | 0.0343 ms | 3.381 ms |

WithInterlocked

|  Method | NumberOfWriters | NumberOfReaders | NumberOfMessages | Priority |     Mean |     Error |    StdDev |   Median |
|-------- |---------------- |---------------- |----------------- |--------- |---------:|----------:|----------:|---------:|
| Process |               1 |              10 |                3 |   Normal | 3.083 ms | 0.0300 ms | 0.0250 ms | 3.090 ms |
| Process |               1 |              10 |               10 |   Normal | 3.326 ms | 0.1277 ms | 0.3495 ms | 3.178 ms |
| Process |              10 |               1 |                3 |   Normal | 4.583 ms | 0.0927 ms | 0.2426 ms | 4.504 ms |
| Process |              10 |               1 |               10 |   Normal | 4.681 ms | 0.1276 ms | 0.3600 ms | 4.591 ms |
| Process |              10 |              10 |                3 |   Normal | 5.158 ms | 0.2389 ms | 0.6620 ms | 5.044 ms |
| Process |              10 |              10 |               10 |   Normal | 5.118 ms | 0.2236 ms | 0.6379 ms | 4.937 ms |
| Process |              10 |              10 |               10 | BelowNormal | 4.414 ms | 0.0868 ms | 0.1714 ms |
| Process |              10 |              10 |               10 | AboveNormal | 4.420 ms | 0.0873 ms | 0.1434 ms |