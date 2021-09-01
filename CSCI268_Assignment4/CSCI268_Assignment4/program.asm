; CSCI268_Assignment4 

INCLUDE Irvine32.inc

.386
.model flat,stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD


.data
array	BYTE	1, 2, 3, 4			; Array to be summed - Adds to 10 (0Ah)

.code
main PROC

	mov		esi, OFFSET array		; Pointer to array
	mov		ecx, LENGTHOF array		; Times to loop
	call	SumArray

	call	WriteInt				; Write Sum

	mov		al, 10					; newline char
	call	WriteChar				; Print to seperate lines

	mov		al, '?'
	call	ColorMatrix
	
	INVOKE	ExitProcess,0
main ENDP

;-------------------------------------------------
; SumArray
;
; Calculates sum of an array of BYTEs
; Recieves:	ESI = Array Offset
;			ECX = Number of elements in array
; Returns:	EAX = Sum of array elements
;-------------------------------------------------
SumArray PROC
	push	esi						; Save memory
	push	ecx
	push	ebx

	mov		eax, 0					; Clear memory
L1:
	movsx	ebx, BYTE PTR [esi]		; Move with sign extend, in order to properly add BYTE to EAX
	add		eax, ebx
	add		esi, TYPE BYTE
	loop	L1

	pop		ebx						; Restore memory
	pop		ecx
	pop		esi

	ret
SumArray ENDP

;-------------------------------------------------
; ColorMatrix
;
; Prints a character in all 256 text and background colors
; Recieves:	AL = Character to print
;-------------------------------------------------
ColorMatrix PROC
	; Save memory
	push	eax						; Full color pallete
	push	ebx						; Background color
	push	ecx						; Loop variable
	push	edx						; Character
	push	esi						; Original color

	mov		dl, al					; Store character for print

	call	GetTextColor			; Get original color
	mov		esi, eax				; Save for later

	mov		ecx, 16
	L2:
		mov		eax, 0					; Clear memory
		mov		ebx, ecx				; This is our background color
		dec		ebx						; (1-16) -> (0-15)
		shl		ebx, 4					; Shift into background color position

		push	ecx						; Save loop val to stack
		mov		ecx, 16
		L3:
			mov		eax, ecx			; Set text color
			dec		eax					; (1-16) -> (0-15)
			add		eax, ebx			; Add background color
			call	SetTextColor		; Upper 4 bits are background, lower are text color

			mov		al, dl					; Move for call
			call	WriteChar
		loop	L3
		pop		ecx						; Restore loop var
	loop	L2

	mov		eax, esi				; Move original color to EAX for call
	call	SetTextColor

	; Restore memory
	pop		esi
	pop		edx
	pop		ecx
	pop		ebx
	pop		eax

	ret
ColorMatrix ENDP

END main