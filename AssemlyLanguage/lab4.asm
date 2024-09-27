ans db 0
mass db 01101010b, 10000010b, 01011001b, 00111100b, 01110111b, 10100101b


     mov si, offset mass
     mov cx, 6*8
     mov al, 1
beg: test [si], al
     jnz @1
     inc ans
@1:  rol al, 1
     adc si, 0
     loop beg
 
