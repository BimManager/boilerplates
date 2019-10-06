// N/A LLC
// Author: kkozlov
// main.c

#include <setjmp.h>
#include <stdio.h>

int	main(void)
{
  __asm__ volatile ("movq $42, %rax\n\t"
		    "popq %rbp\n\t"
		    "retq");
}
