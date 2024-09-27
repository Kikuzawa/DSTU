; Data segment
data segment
    TEXT1 db 'This is the first line of text', '$'
    TEXT2 db 'Here is the second line', '$'
    TEXT3 db 'And this is the third line', '$'
    TEXT4 db 'Press ESC to change colors', '$'
    OLD_CS dw ?  ; Old CS register value
    OLD_IP dw ?  ; Old IP register value
    CURRENT_ATTR db 14  ; Starting attribute (yellow)
data ends

; Code segment
code segment
    assume cs:code, ds:data

    NEW_27 proc far ; new prerivanie int 5h
        push ax
        push bx
        push cx
        push dx
        push ds
        push es

        ; Set up video memory address
        mov ax, 0B800h
        mov es, ax

        ; Increment attribute, loop back to 1 if it reaches 16
        inc [CURRENT_ATTR]
        cmp [CURRENT_ATTR], 16
        jne skip_reset
        mov [CURRENT_ATTR], 1
    skip_reset:

        ; Change attribute for all characters on screen
        mov cx, 2000  ; 80x25 characters
        xor di, di    ; Start from the beginning of video memory
        mov ah, [CURRENT_ATTR]
    change_attr:
        mov al, es:[di]  ; Get character
        stosw            ; Store character with new attribute
        loop change_attr

        ; Restore saved registers
        pop es
        pop ds
        pop dx
        pop cx
        pop bx
        pop ax
        iret
    NEW_27 endp

    CLS proc near
        push cx
        push ax
        push di
        mov ax, 0B800h
        mov es, ax
        xor di, di
        mov ax, 0720h  ; Space character with black background
        mov cx, 2000   ; 80x25 characters
        rep stosw
        pop di
        pop ax
        pop cx
        ret
    CLS endp

    PRINT_TEXT proc near
        push si
        push di
        push cx
    print_loop:
        lodsb
        stosw
        loop print_loop
        pop cx
        pop di
        pop si
        ret
    PRINT_TEXT endp

    start:
        mov ax, data
        mov ds, ax

        ; Save old interrupt vector
        mov ah, 35h
        mov al, 27h  ; Changed to 27h for ESC key
        int 21h
        mov OLD_IP, bx
        mov OLD_CS, es

        ; Set new interrupt vector
        push ds
        mov dx, offset NEW_27
        mov ax, seg NEW_27
        mov ds, ax
        mov ah, 25h
        mov al, 27h  ; Changed to 27h for ESC key
        int 21h
        pop ds

        ; Clear screen
        call CLS

        ; Set up video memory
        mov ax, 0B800h
        mov es, ax
        mov ah, 14  ; Yellow attribute

        ; Print TEXT1
        mov si, offset TEXT1
        mov di, 160  ; Second row
        mov cx, 29   ; Length of TEXT1
        call PRINT_TEXT

        ; Print TEXT2
        mov si, offset TEXT2
        mov di, 480  ; Fourth row
        mov cx, 24   ; Length of TEXT2
        call PRINT_TEXT

        ; Print TEXT3
        mov si, offset TEXT3
        mov di, 800  ; Sixth row
        mov cx, 27   ; Length of TEXT3
        call PRINT_TEXT

        ; Print TEXT4
        mov si, offset TEXT4
        mov di, 1120 ; Eighth row
        mov cx, 28   ; Updated length of TEXT4
        call PRINT_TEXT

    wait_key:
        mov ah, 0
        int 16h
        
        cmp al, 48  ; ASCII code for '0'
        je quit      
        
        jmp change_color
        

    change_color:
        int 27h  ; Call our new interrupt handler
        jmp wait_key

    quit:
        ; Restore old interrupt vector
        mov dx, OLD_IP
        mov ax, OLD_CS
        mov ds, ax
        mov ah, 25h
        mov al, 27h  ; Changed to 27h for ESC key
        int 21h

        mov ax, 4C00h
        int 21h

code ends
end start
