har2csv
=======

Convert Http ARchive files to csv output

Usage
-----

### Read from a file, write to a file

`#> har2csv -i somefile.har -o anotherfile.csv`

### Read from input stream, write to a file

`#> gc somefile.har | har2csv -o anotherfile.csv`

### Read from a file, write to output stream

`#> har2csv -i somefile.har`

### Read from input stream, write to output stream

`#> gc somefile.har | har2csv