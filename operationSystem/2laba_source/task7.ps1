$n = 100
'dir'; 1..$n | foreach {Measure-Command {dir $env:SystemRoot}} |Measure-Object TotalMilliseconds -Max -Min -Average

'ps'; 1..$n | foreach {Measure-Command {ps}} |Measure-Object TotalMilliseconds -Max -Min -Average
