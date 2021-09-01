; 
; CSCI268_Assignment6
; Alex Phelps
;

include Irvine32.inc

.386
.model flat,stdcall
.stack 4096
ExitProcess proto,dwExitCode:dword

.code
main proc

	push 508Fh		; 04/15/2020 in FAT format
	call DateParts

	add bh, 1		; Add a day

	movzx ax, bl	; You can't push a single byte, so we are going to mov to ax and push that
	push ax			; Month
	movzx ax, bh	; Same as above ^^
	push ax			; Day
	push cx			; Year
	call DateNumber


	call DumpRegs	; for debugging / memory checks
					; AX = FAT number
					; BL = Month
					; BH = Day
					; CX = Year

	invoke ExitProcess,0
main endp


;-------------------------------------------------
; DateNumber
;
; Calculates FAT date formatted number from individual parts
; Recieves:	[ebp + 12] = Month
;			[ebp + 10] = Day
;			[ebp + 8] = Year
; Returns:	AX = FAT formatted date number
;-------------------------------------------------
DateNumber proc
	push ebp			; stack frame
	mov ebp, esp

	push bx				; preserve registers
	push cx

	mov bl, [ebp + 12]	; Store parameters in workable memory
	mov bh, [ebp + 10]
	mov cx, [ebp + 8]

	sub cx, 1980		; years since 1980

	mov ax, cx			; mov year
	shl ax, 4			; shift ax to make room for month (4 bits)
	
	and bl, 00001111b	; this clears top 4 bits, so we make sure we are only using 4 bits
	or al, bl			; combine day (bottom 4 bits) into FAT number
	shl ax, 5			; shift ax to make room for day (5 bits)

	and bh, 00011111b	; this clears top 3 bits, so we make sure we are only using 5 bits
	or al, bh			; combine day (bottom 5 bits) into FAT number


	; Final bit positions
	; YYYYYYYMMMMDDDDD

	pop cx				; pop registers
	pop bx

	pop ebp				; clean stack
	ret 6
DateNumber endp

;-------------------------------------------------
; DateParts
;
; Calculates date parts from FAT formatted number
; Recieves:	[ebp + 8] = FAT formatted date number
; Returns:	BL = Month
;			BH = Day
;			CX = Year
;-------------------------------------------------
DateParts proc
	push ebp			; stack frame
	mov ebp, esp

	mov cx, [ebp + 8]	; mov entire format to year registar (for manipulation)

	mov bh, cl			; mov day bots + 3 
	and bh, 00011111b	; clear extra month bits (top 3)

	shr cx, 5			; shift out day bits
	mov bl, cl			; mov month bots + 3
	and bl, 00011111b	; clear extra year bits (top 3)

	mov cx, [ebp + 8]	; mov entire format to year registar
	shr cx, 9			; shift day/month bots out, year bits into position
	add cx, 1980		; add start year
	
	pop ebp				; clean stack
	ret 2
DateParts endp

end main