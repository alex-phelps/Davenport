; 
; CSCI268_Assignment5
; Alex Phelps
;

include Irvine32.inc

.386
.model flat,stdcall
.stack 4096
ExitProcess proto,dwExitCode:dword

.code
main proc

	mov ax, 508Fh	; 04/15/2020 in FAT format

	call DateParts

	add bh, 1		; Add a day

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
; Recieves:	BL = Month
;			BH = Day
;			CX = Year
; Returns:	AX = FAT formatted date number
;-------------------------------------------------
DateNumber proc
	push bx
	push cx

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

	pop cx
	pop bx
	ret
DateNumber endp

;-------------------------------------------------
; DateParts
;
; Calculates date parts from FAT formatted number
; Recieves:	AX = FAT formatted date number
; Returns:	BL = Month
;			BH = Day
;			CX = Year
;-------------------------------------------------
DateParts proc
	mov cx, ax			; mov entire format to year registar (for manipulation)

	mov bh, cl			; mov day bots + 3 
	and bh, 00011111b	; clear extra month bits (top 3)

	shr cx, 5			; shift out day bits
	mov bl, cl			; mov month bots + 3
	and bl, 00011111b	; clear extra year bits (top 3)

	mov cx, ax			; mov entire format to year registar
	shr cx, 9			; shift day/month bots out, year bits into position
	add cx, 1980		; add start year
	
	ret
DateParts endp

end main