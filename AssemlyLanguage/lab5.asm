.model small
.stack 100h
.data
    str1 db 100 dup('$')  ; First string
    str2 db 100 dup('$')  ; Second string
    prompt1 db 'Enter first string: $'
    prompt2 db 'Enter second string: $'
    result db 'Position: $'
    not_found_msg db 'Not found$'

.code
main proc
    mov ax, @data
    mov ds, ax

    ; Input first string
    mov ah, 9
    lea dx, prompt1
    int 21h
    mov ah, 0Ah
    lea dx, str1
    mov byte ptr [str1], 98
    int 21h
    
    ; New line
    mov ah, 2
    mov dl, 0Dh
    int 21h
    mov dl, 0Ah
    int 21h

    ; Input second string
    mov ah, 9
    lea dx, prompt2
    int 21h
    
    mov ah, 0Ah
    lea dx, str2
    mov byte ptr [str2], 98
    int 21h
    
    ; New line
    mov ah, 2
    mov dl, 0Dh
    int 21h
    mov dl, 0Ah
    int 21h

    ; Compare strings
    lea si, str1 + 2; Skip two service bytes
    lea di, str2 + 2
    mov cx, 1; Initial position

compare_loop:
    mov al, [si]
    cmp al, '$'
    je not_found_label

    push si
    push di
    push cx

check_match:
    mov al, [si]
    mov bl, [di]
    cmp bl, '$'
    je found

    cmp al, bl
    jne no_match

    inc si
    inc di
    jmp check_match

no_match:
    pop cx
    pop di
    pop si
    inc si
    inc cx
    jmp compare_loop

found:
    pop cx
    pop di
    pop si

    ; Output result
    mov ah, 9
    lea dx, result
    int 21h

    mov ax, cx
    call print_num
    jmp exit

not_found_label:
    mov ah, 9
    lea dx, not_found_msg
    int 21h

exit:
    mov ah, 4Ch
    int 21h
main endp

; Subroutine for printing a number
print_num proc
    mov cx, 0
    mov bx, 10

divide_loop:
    xor dx, dx
    div bx
    push dx
    inc cx
    test ax, ax
    jnz divide_loop

print_loop:
    pop dx
    add dl, '0'
    mov ah, 2
    int 21h
    loop print_loop

    ret
print_num endp

end main
