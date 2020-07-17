/*
** Copyright 2020 kkozlov
*/

/*
** comment block
** include statements
** data type, constant and macro definitions
** static data declarations
** private function prototypes
** public function bodies
** private function bodies
*/

#include <setjmp.h>
#include <stdio.h>

int	main(void)
{
  __asm__ volatile ("movq $42, %rax\n\t"
		    "popq %rbp\n\t"
		    "retq");
}
