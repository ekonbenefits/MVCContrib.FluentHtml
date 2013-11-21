$artifacts = gci src/ -r -include obj, bin
foreach($a in $artifacts) {
    remove-item -force -Recurse -path $a
}