# Makefile

CC := gcc
LD := ld
CFLAGS := -Wall -Werror -I./$(INDIR) -c
LDFLAGS := -lc -e _main -arch x86_64

INDIR := include 
SRCDIR := src
OBJDIR := build
BINDIR := bin

SRCEXT := c

HDRS := 
SRCS := $(shell find -s $(SRCDIR) -name *.$(SRCEXT))
#OBJS := $(patsubst $(SRCDIR)/%, $(OBJDIR)/%,$(SRC:.c=.o))
OBJS := $(patsubst $(SRCDIR)/%.c, $(OBJDIR)/%.o, $(SRCS))
NAME := a.out


all : $(NAME)

$(NAME) : $(OBJS)
	@echo $(SRCS)
	@echo $(OBJS)
	$(LD) $(LDFLAGS) $^ -o $(BINDIR)/$@

$(OBJDIR)/%.o : $(SRCDIR)/%.c
	mkdir $(OBJDIR)
	$(CC) $(CFLAGS) $< -o $@

.PNOHY : all clean fclean re

clean :
	@rm -rf $(OBJDIR)

fclean : clean
	@rm -rf $(BINDIR)/$(NAME)

re : fclean all