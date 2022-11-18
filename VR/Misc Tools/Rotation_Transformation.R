angle <- function(x){
  x*pi/180
}

point1 <- c(1, -1, 0)
point2 <- c(7, -2, 5)
point3 <- c(10, 6, -4)

x_trans <- t(matrix(ncol = 3,
                    data = c(1, 0, 0,
                             0, cos(angle(30)), -sin(angle(30)),
                             0, sin(angle(30)), cos(angle(30)))))
y_trans <- matrix(ncol = 3,
                  data = c(cos(angle(60)), 0, sin(angle(60)),
                           0, 1, 0,
                           -sin(angle(60)), 0, cos(angle(60))),
                  byrow = TRUE)
z_trans <- matrix(ncol = 3,
                  data = c(cos(angle(45)), -sin(angle(45)), 0,
                           sin(angle(45)), cos(angle(45)), 0,
                           0, 0, 1),
                  byrow = TRUE)

total_trans <- y_trans %*% (z_trans %*% x_trans)

t(total_trans %*% point1 + shift)
t(total_trans %*% point2 + shift)
t(total_trans %*% point3 + shift)