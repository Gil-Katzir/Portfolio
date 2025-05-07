### סעיף 1 
dataset <- read.csv(file.choose(), header = TRUE, fileEncoding = "ISO-8859-1", check.names = FALSE)

##סעיפים 2,3 ללא קוד

### סעיף 4

continuous_vars <- dataset[, sapply(dataset, is.numeric), drop = FALSE]
continuous_vars$'country index' <- NULL


plot(continuous_vars)

#Median age and smoke rate---
plot(x=continuous_vars$"Median age",y=continuous_vars$"Smoke rate",xlab="Median age",ylab="Smoke rate",lwd = 2)
correlation <- cor(continuous_vars$`Median age`, continuous_vars$`Smoke rate`)
print(paste("Correlation:", correlation))

#State Development Index and Depression rate---
plot(x=continuous_vars$"State Development Index (0-1)",y=continuous_vars$"Depression rate (%)",xlab="State Development Index (0-1)",ylab="Depression rate (%)",lwd = 2)
correlation <- cor(continuous_vars$`Depression rate (%)`, continuous_vars$`State Development Index (0-1)`)
print(paste("Correlation:", correlation))

#Average temperature and Smoke rate
plot(x=continuous_vars$"Average temperature",y=continuous_vars$"Smoke rate",xlab="Average temperature",ylab="Smoke rate",lwd = 2)
correlation <- cor(continuous_vars$`Smoke rate`, continuous_vars$`Average temperature`)
print(paste("Correlation:", correlation))

#state devlopment Index and median age---
plot(x=continuous_vars$"State Development Index (0-1)",y=continuous_vars$"Median age",xlab="State Development Index (0-1)",ylab="Median age",lwd = 2)
correlation <- cor(continuous_vars$`Median age`, continuous_vars$`State Development Index (0-1)`)
print(paste("Correlation:", correlation))

#Average temperature and State Development Index---
plot(x=continuous_vars$"Average temperature",y=continuous_vars$"State Development Index (0-1)",xlab="Average temperature",ylab="State Development Index (0-1)",lwd = 2)
correlation <- cor(continuous_vars$`Average temperature`, continuous_vars$`State Development Index (0-1)`)
print(paste("Correlation:", correlation))



### סעיף 5

install.packages("e1071")
library(e1071)

summary(dataset$'Obesity rate')
sd(dataset$'Obesity rate')
skewness(dataset$'Obesity rate')
IQR(dataset$'Obesity rate')

summary(dataset$'Smoke rate')
sd(dataset$'Smoke rate')
skewness(dataset$'Smoke rate')
IQR(dataset$'Smoke rate')

summary(dataset$'Median age')
sd(dataset$'Median age')
skewness(dataset$'Median age')
IQR(dataset$'Median age')

summary(dataset$'Average temperature')
sd(dataset$'Average temperature')
skewness(dataset$'Average temperature')
IQR(dataset$'Average temperature')


State_Development <- dataset$`State Development Index (0-1)`
summary(State_Development)
sd(State_Development)
skewness(State_Development)
IQR(State_Development)

summary(dataset$'Depression rate')
sd(dataset$'Depression rate')
skewness(dataset$'Depression rate')
IQR(dataset$'Depression rate')

summary(dataset$'Cancer mortality rate')
sd(dataset$'Cancer mortality rate')
skewness(dataset$'Cancer mortality rate')
IQR(dataset$'Cancer mortality rate')

#משתנה קטגוריאלי
grouped_data <- split(dataset, dataset$`Air pollution index`)

for (category in names(grouped_data)) {
  subset_data <- grouped_data[[category]]$`Cancer mortality rate (%)`
  
  cat("קטגוריה:", category, "\n")
  
  cat("Summary:\n")
  print(summary(subset_data))
  
  sd_value <- sd(subset_data)
  cat("Standard Deviation:", sd_value, "\n")
  
  skewness_value <- skewness(subset_data)
  cat("Skewness:", skewness_value, "\n")
  
  iqr_value <- IQR(subset_data)
  cat("IQR (Interquartile Range):", iqr_value, "\n")
  
  cat("----------\n")
} 

### סעיף 6

#Create boxplot for "Obesity Rate"
bp<-boxplot(dataset$`Obesity rate`, main = "Obesity Rate", 
            ylab = "Obesity Rate (%)", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 


#######################

#Create boxplot for "Smoke rate"
bp<-boxplot(dataset$`Smoke rate`, main = "Smoke rate", 
            ylab = "Smoke Rate (%)", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 



######################

#Create boxplot for "State Development Index (0-1)"
bp<-boxplot(dataset$`State Development Index (0-1)`, main = "State Development Index (0-1)", 
            ylab = "State Development Index (0-1)", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 



##############################

#Create boxplot for "Median age"
bp<-boxplot(dataset$`Median age`, main = "Median age", 
            ylab = "Median age", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 


####################################

#Create boxplot for "Average temperature"
bp<-boxplot(dataset$`Average temperature`, main = "Average temperature", 
            ylab = "Average temperature", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 

####################################

#Create boxplot for "Percentage of residents in cities"
bp<-boxplot(dataset$`Percentage of residents in cities`, main = "Percentage of residents in cities", 
            ylab = "Percentage of residents in cities", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 


# Identify the largest outlier
largest_outlier <- max(bp$out)

# Filter dataset by removing the largest outlier
filtered_dataset <- subset(dataset, dataset$`Percentage of residents in cities` != largest_outlier)

# new boxplot without the largest outlier
bp_filtered <- boxplot(filtered_dataset$`Percentage of residents in cities`, main = "Filtered Percentage of residents in cities", 
                       ylab = "Percentage of residents in cities", col = "turquoise", outline = TRUE)



#########################

#Create boxplot for "Depression rate (%)"
bp<-boxplot(dataset$`Depression rate (%)`, main = "Depression rate (%)", 
            ylab = "Depression rate (%)", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 

###################################

#Create boxplot for "Cancer mortality rate (%)"
bp<-boxplot(dataset$`Cancer mortality rate (%`, main = "Cancer mortality rate (%", 
            ylab = "Cancer mortality rate (%", col = "turquoise")

# 1- Lower Bound, 2- Q1 , 3-Median , 4-Q3 , 5 - Upperbound
bp$stats 

#outliers
bp$out 



### סעיף 7

# היסטוגרמה עבור Obesity rate
hist(dataset$`Obesity rate`, 
     main = "Histogram of Obesity Rate", 
     xlab = "Obesity Rate (%)", 
     col = "turquoise", 
     border = "black", 
     probability = TRUE)
lines(density(dataset$`Obesity rate`), col = "blue", lwd = 3)  # צפיפות הסתברות

# פונקציית התפלגות מצטברת עבור Obesity rate
plot(ecdf(dataset$`Obesity rate`), 
     main = "Cumulative Distribution of Obesity Rate", 
     xlab = "Obesity Rate (%)", 
     ylab = "Cumulative Probability", 
     col = "turquoise")

# היסטוגרמה עבור Smoke rate
hist(dataset$`Smoke rate`, 
     main = "Histogram of Smoke Rate", 
     xlab = "Smoke Rate (%)", 
     col = "turquoise", 
     border = "black", 
     probability = TRUE)
lines(density(dataset$`Smoke rate`), col = "blue", lwd = 3)  # צפיפות הסתברות

# פונקציית התפלגות מצטברת עבור Smoke rate
plot(ecdf(dataset$`Smoke rate`), 
     main = "Cumulative Distribution of Smoke Rate", 
     xlab = "Smoke Rate (%)", 
     ylab = "Cumulative Probability", 
     col = "turquoise")

# היסטוגרמה עבור Depression rate
hist(dataset$`Depression rate`, 
     main = "Histogram of Depression Rate", 
     xlab = "Depression Rate (%)", 
     col = "turquoise", 
     border = "black", 
     probability = TRUE)
lines(density(dataset$`Depression rate`), col = "blue", lwd = 3)  # צפיפות הסתברות

# פונקציית התפלגות מצטברת עבור Depression rate
plot(ecdf(dataset$`Depression rate`), 
     main = "Cumulative Distribution of Depression Rate", 
     xlab = "Depression Rate (%)", 
     ylab = "Cumulative Probability", 
     col = "turquoise")



### סעיף 8
dataset$continent_color <- ifelse(dataset$`Continent` == "Europe", "#4CAF50",
                                  ifelse(dataset$`Continent` == "North America", "#FFC107",
                                         ifelse(dataset$`Continent` == "Australia", "#1f77b4",
                                                ifelse(dataset$`Continent` == "Asia", "#D32F2F",
                                                       ifelse(dataset$`Continent` == "Africa", "#9467bd",
                                                              ifelse(dataset$`Continent` == "South America", "#40E0D0", NA))))))

plot(x=dataset$`Obesity rate`,y=dataset$`Cancer mortality rate (%)`,main="Scatter Plot of Obesity Rate vs Cancer mortality rate",xlab="Obesity rate", ylab="Cancer mortality rate (%)",col=dataset$"continent_color",cex=1.5,pch=19,cex.main = 1.5)


#הדפסת המקרא
legend("topright",
       legend = c("Europe", "North America", "Australia", "Asia", "Africa", "South America"),
       col = c("#4CAF50", "#FFC107", "#1f77b4", "#D32F2F", "#9467bd", "#40E0D0"),
       pch = 19,
       inset = c(-0.3, 0),
       xpd = NA,
       bty = "n",
       cex = 0.9)

### סעיף 9


##גרף כינור##
valid_groups <- names(which(table(dataset$`Air pollution index`) >= 2))
filtered_group <- dataset$`Air pollution index`[dataset$`Air pollution index` %in% valid_groups]
filtered_values <- dataset$`Cancer mortality rate (%)`[dataset$`Air pollution index` %in% valid_groups]

# יצירת גרף Violin Plot
plot.new()
plot.window(xlim = c(0.5, length(unique(filtered_group)) + 0.5), 
            ylim = range(filtered_values, na.rm = TRUE))

# הוספת צפיפות לכל קבוצה
for (i in seq_along(valid_groups)) {
  group_values <- filtered_values[filtered_group == valid_groups[i]]
  
  # בדיקה אם יש יותר מ-1 תצפיות בקבוצה
  if (length(group_values) > 1) {
    density_values <- density(group_values, na.rm = TRUE)
    
    # התאמת מיקום ורוחב הפוליגון
    x_coords <- i + 0.4 * density_values$y / max(density_values$y)
    y_coords <- density_values$x
    polygon(c(i - 0.4 * density_values$y / max(density_values$y), rev(x_coords)), 
            c(y_coords, rev(y_coords)), 
            col = rgb(0.2, 0.4, 0.6, 0.5), border = NA)
  }
}

# הוספת נקודות בודדות (תצפיות)
stripchart(filtered_values ~ filtered_group, vertical = TRUE, method = "jitter", 
           pch = 19, col = rgb(0.1, 0.5, 0.8, 0.5), add = TRUE)

# הוספת כותרות וצירים
title(main = "Violin Plot: Air Pollution vs Cancer Mortality", 
      xlab = "Air Pollution Levels", 
      ylab = "Cancer Mortality Rate (%)")
axis(1, at = 1:length(valid_groups), labels = valid_groups)
axis(2)

##גרף משולב צפיפות##
install.packages("ggplot2")

# טעינת הספרייה
library(ggplot2)

# יצירת Density Contour Plot
ggplot(continuous_vars, aes(x = `Smoke rate`, y = `Cancer mortality rate (%)`)) +
  stat_density_2d(aes(color = after_stat(level)), geom = "density_2d", linewidth = 1.2) + 
  scale_color_gradient(low = "green", high = "red") +
  labs(
    title = "Relationship Between Smoking Rate and Cancer Mortality: Density Contour Analysis",
    x = "Smoke Rate",
    y = "Cancer Mortality Rate",
    color = "Density Level"
  ) +
  theme_minimal()



### סעיף 10

table_2d <- table(dataset$Continent, dataset$`Air pollution index`)
print(table_2d)
# חישוב טבלה באחוזים
table_2d_percent <- prop.table(table_2d) * 100
# הדפסת טבלת האחוזים
print(table_2d_percent)

# טבלת שכיחות חד-ממדית עבור היבשות
continent_table <- table(dataset$Continent)
print(continent_table)
continent_table_percent <- prop.table(continent_table) * 100
# הדפסת טבלת האחוזים
print(continent_table_percent)

# טבלת שכיחות חד-ממדית עבור זיהום האוויר
pollution_table <- table(dataset$`Air pollution index`)
print(pollution_table)
pollution_table_percent <- prop.table(pollution_table) * 100
# הדפסת טבלת האחוזים
print(pollution_table_percent)
