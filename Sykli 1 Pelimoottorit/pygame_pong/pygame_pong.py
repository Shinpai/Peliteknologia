"""
@haeejuut
 Based on pygame template for opening a window
 http://programarcadegames.com/python_examples/f.php?file=pygame_base_template.py
"""

import pygame

# Define some colors
BLACK = (0, 0, 0)
WHITE = (255, 255, 255)

pygame.init()

# Set the width and height of the screen [width, height]
size = width, height = (700, 500)
screen = pygame.display.set_mode(size)

pygame.display.set_caption("Pygame PONG")

# Used to manage how fast the screen updates
clock = pygame.time.Clock()

# SCORES
scores = [0, 0]


def main():
    # -------- Game Objects -----------
    # THE BOX
    border_s = 10  # size of the borders
    BORDER_BOTTOM = pygame.Rect(0, 20, width, border_s)
    BORDER_TOP = pygame.Rect(0, height - 20, width, border_s)
    BORDER_LEFT = pygame.Rect(0, 0, border_s, height)
    BORDER_RIGHT = pygame.Rect(width, 0, border_s, height)

    # PLAYER
    pad_left = pygame.Rect(25, 200, 10, 60)
    # AI
    pad_right = pygame.Rect(width - 35, 200, 10, 60)
    # BALL
    x_dir, y_dir = -4, 1  # vector for movement
    ball = pygame.Rect(width / 2, height / 2, 15, 15)

    # Loop until the user clicks the close button.
    done = False
    # -------- Main Program Loop -----------
    while not done:
        # --- Main event loop
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                done = True
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_ESCAPE:
                    done = True

        # Detect keypresses
        keys = pygame.key.get_pressed()
        if keys[pygame.K_UP]:
            if pad_left.y > 40:
                pad_left.y -= 3
        if keys[pygame.K_DOWN]:
            if pad_left.y < height - 100:
                pad_left.y += 3

        # --- Game logic should go here
        # UPDATE BALL POS
        ball.x += x_dir
        ball.y += y_dir

        # UPDATE AI POS
        if pad_right.y < ball.y and pad_right.y < height - 100:
            pad_right.y += 1
        if pad_right.y > ball.y and pad_right.y > 40:
            pad_right.y += -1

        # PAD COLLISION
        if ball.colliderect(pad_left) or ball.colliderect(pad_right):
            x_dir = -x_dir

        # TOP/BOTTOM COLLISION
        if ball.colliderect(BORDER_TOP) or ball.colliderect(BORDER_BOTTOM):
            y_dir = -y_dir

        # SCORING COLLISION
        if ball.colliderect(BORDER_RIGHT):
            scores[0] += 1
            main()
        if ball.colliderect(BORDER_LEFT):
            scores[1] += 1
            main()

        # --- Screen-clearing code goes here
        screen.fill(WHITE)

        # --- Drawing code should go here
        pygame.draw.rect(screen, BLACK, pad_left)
        pygame.draw.rect(screen, BLACK, pad_right)
        pygame.draw.rect(screen, BLACK, ball)

        pygame.draw.rect(screen, BLACK, BORDER_BOTTOM)
        pygame.draw.rect(screen, BLACK, BORDER_TOP)
        pygame.draw.rect(screen, BLACK, BORDER_RIGHT)

        # --- Update the changes to screen
        pygame.display.set_caption("Pygame PONG " + str(scores[0]) + ' - ' + str(scores[1]))
        pygame.display.flip()

        # --- Limit to 60 frames per second
        clock.tick(60)

    # Close the window and quit.
    pygame.quit()

if __name__ == '__main__':
    main()
