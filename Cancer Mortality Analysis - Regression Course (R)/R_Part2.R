#טעינת בסיס הנתונים
dataset <- read.csv(file.choose(), header = TRUE, fileEncoding = "ISO-8859-1", check.names = FALSE)
original_dataset <- dataset

#טעינת ספריות נחוצות

install.packages("e1071")
install.packages("ggplot2")
install.packages("strucchange")
install.packages("MASS")

############################ PART A ################################


#### PART A Q.4 ####
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


#### PART A Q.5 ####

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

#### PART A Q.6 ####

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


#### PART A Q.7 ####

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



#### PART A Q.8 ####

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


#### PART A Q.9 ####

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



#### PART A Q.10 ####

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

################################# PART B ##################################

# update dataset 

dataset <- dataset[, c("Obesity rate",
                       "Smoke rate",
                       "Air pollution index",
                       "State Development Index (0-1)",
                       "Median age",
                       "Average temperature",
                       "Percentage of residents in cities",
                       "Depression rate (%)",
                       "Continent",
                       "Cancer mortality rate (%)")]


#### Q.2.1 ####

# חישוב מתאם פירסון לכל משתנה רציף מול המשתנה המוסבר
corObesityRate <- cor(dataset$`Obesity rate`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between Obesity rate and Cancer mortality rate:", corObesityRate))

corSmokeRate <- cor(dataset$`Smoke rate`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between Smoke rate and Cancer mortality rate:", corSmokeRate))

corStateDevIndex <- cor(dataset$`State Development Index (0-1)`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between State Development Index and Cancer mortality rate:", corStateDevIndex))

corMedianAge <- cor(dataset$`Median age`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between Median age and Cancer mortality rate:", corMedianAge))

corAverageTemp <- cor(dataset$`Average temperature`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between Average temperature and Cancer mortality rate:", corAverageTemp))

corResidentsInCities <- cor(dataset$`Percentage of residents in cities`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between Percentage of residents in cities and Cancer mortality rate:", corResidentsInCities))

corDepressionRate <- cor(dataset$`Depression rate (%)`, dataset$`Cancer mortality rate (%)`, use = "complete.obs", method = "pearson")
print(paste("Correlation between Depression rate and Cancer mortality rate:", corDepressionRate))



plot(dataset$`Depression rate (%)`, dataset$`Cancer mortality rate (%)`,
     main = "Scatter Plot: Depression Rate vs Cancer Mortality Rate",
     xlab = "Depression Rate (%)",
     ylab = "Cancer Mortality Rate (%)",
     pch = 19,        # צורת הנקודות
     col = "pink")    # צבע הנקודות

# גרף פיזור
plot(dataset$`Percentage of residents in cities`, dataset$`Cancer mortality rate (%)`,
     main = "Scatter Plot: Percentage of Residents in Cities vs Cancer Mortality Rate",
     xlab = "Percentage of Residents in Cities (%)",
     ylab = "Cancer Mortality Rate (%)",
     pch = 19,        # צורת הנקודות
     col = "pink")   # צבע הנקודות

model_1 <- lm(dataset$`Cancer mortality rate (%)` ~ dataset$`Depression rate (%)`)
summary(model_1)
model_2 <- lm(dataset$`Cancer mortality rate (%)` ~ dataset$`Percentage of residents in cities`)
summary(model_2)

dataset <- subset(dataset, select = -c(`Percentage of residents in cities`, `Depression rate (%)`))


#### Q.2.2 ####

model_before <- lm(`Cancer mortality rate (%)` ~ `Air pollution index`,data = dataset)
summary(model_before)

#בדיקת האופציה: איחוד קטגוריות במשתנה "Air Pollution Index" הקטגוריאלי  

# יצירת גרף BOXPLOT להשוואת הפיזורים
boxplot(dataset$`Cancer mortality rate` ~ dataset$`Air pollution index`,
        main = "Boxplot of Cancer Mortality Rate by Air Pollution Index Categories",
        xlab = "Air Pollution Index",
        ylab = "Cancer Mortality Rate",
        col = c("#E6E6FA", "#D8BFD8", "#DA70D6", "#BA55D3", "#8A2BE2"),
        border = "black")

# הוספת רשת לרקע
grid()


category_counts <- table(dataset$`Air pollution index`)
print(category_counts)


# חישוב ממוצע לפי קטגוריה
mean_stats <- aggregate(dataset$`Cancer mortality rate`, 
                        by = list(Category = dataset$`Air pollution index`), 
                        FUN = mean, na.rm = TRUE)

# חישוב חציון לפי קטגוריה
median_stats <- aggregate(dataset$`Cancer mortality rate`, 
                          by = list(Category = dataset$`Air pollution index`), 
                          FUN = median, na.rm = TRUE)

# חישוב סטיית תקן לפי קטגוריה
sd_stats <- aggregate(dataset$`Cancer mortality rate`, 
                      by = list(Category = dataset$`Air pollution index`), 
                      FUN = sd, na.rm = TRUE)

# חישוב מינימום לפי קטגוריה
min_stats <- aggregate(dataset$`Cancer mortality rate`, 
                       by = list(Category = dataset$`Air pollution index`), 
                       FUN = min, na.rm = TRUE)

# חישוב מקסימום לפי קטגוריה
max_stats <- aggregate(dataset$`Cancer mortality rate`, 
                       by = list(Category = dataset$`Air pollution index`), 
                       FUN = max, na.rm = TRUE)

# יצירת טבלה מסכמת עם כל הסטטיסטיקות
statistics <- data.frame(
  Category = mean_stats$Category,
  Mean = mean_stats$x,
  Median = median_stats$x,
  SD = sd_stats$x,
  Min = min_stats$x,
  Max = max_stats$x
)

# הצגת הטבלה
print(statistics)


# תיקון הקטגוריות הקיימות במשתנה "Air pollution index"
dataset$`Air pollution index` <- factor(dataset$`Air pollution index`, 
                                        levels = c("Minor pollution", 
                                                   "Low pollution", 
                                                   "Medium pollution", 
                                                   "High pollution", 
                                                   "Extreme pollution"))

# יצירת קטגוריות מאוחדות
dataset$`Air pollution index` <- ifelse(dataset$`Air pollution index` == "Minor pollution", 
                                        "Minor pollution",
                                        ifelse(dataset$`Air pollution index` %in% c("Low pollution", "Medium pollution"),
                                               "Medium pollution",
                                               ifelse(dataset$`Air pollution index` %in% c("High pollution", "Extreme pollution"),
                                                      "High pollution", NA)))


# הגדרת הקטגוריות מחדש כ-factors
dataset$`Air pollution index` <- factor(dataset$`Air pollution index`, 
                                        levels = c("Minor pollution", "Medium pollution", "High pollution"))

# יצירת גרף BOXPLOT עם הקטגוריות החדשות
boxplot(dataset$`Cancer mortality rate` ~ dataset$`Air pollution index`,
        main = "Boxplot of Cancer Mortality Rate by Modified Air Pollution Categories",
        xlab = "Air Pollution Index (Modified)",
        ylab = "Cancer Mortality Rate",
        col = c("#FFDAB9", "#FFA07A", "#FA8072"),
        border = "black")

# הוספת רשת לגרף
grid()


model_after <- lm(`Cancer mortality rate (%)` ~ `Air pollution index`,data = dataset)
summary(model_after)

# הצגת ערכי Adjusted R^2 של שני המודלים
adj_r2_before <- summary(model_before)$adj.r.squared
adj_r2_after <- summary(model_after)$adj.r.squared

print(paste("Adjusted R^2 before:", round(adj_r2_before, 4)))
print(paste("Adjusted R^2 after:", round(adj_r2_after, 4)))



#בדיקת האופציה: המרת משתנה רציף "State Development Index" לקטגוריאלי	

model_before <- lm(`Cancer mortality rate (%)` ~ `State Development Index (0-1)`,data = dataset)
summary(model_before)



# יצירת גרף פיזור של מדד פיתוח מול שיעור תמותה מסרטן
plot(
  dataset$`State Development Index (0-1)`, 
  dataset$`Cancer mortality rate`,
  main = "Scatter Plot of State Development Index vs Cancer mortality rate ",
  xlab = "State Development Index (0-1)",
  ylab = "Cancer Mortality Rate (%)",
  col = "#8A2BE2",
  pch = 16      
)

# הוספת רשת לרקע
grid()


#בדיקה האם להפוך את למשתנה קטגוריאלי
data_copy <- dataset


data_copy$Development_Category <- cut(
  data_copy$`State Development Index (0-1)`,
  breaks = c(-Inf, 0.6, 0.75, Inf),
  labels = c("Low Development", "Medium Development", "High Development")
)

# הצגת התפלגות הקטגוריות
table(data_copy$Development_Category)

# בדיקה המשתנה מרציף לקטגוריאלי
boxplot(data_copy$`Cancer mortality rate` ~ data_copy$`Development_Category`,
        main = "Boxplot of Cancer Mortality Rate by Development Categories",
        xlab = "Development Categories",
        ylab = "Cancer Mortality Rate (%)",
        col = c("#E6E6FA", "#D8BFD8", "#8A2BE2"),
        border = "black")

# הוספת רשת לרקע
grid()

colnames(dataset)[colnames(dataset) == "State Development Index (0-1)"] <- "State Development"
colnames(data_copy)[colnames(data_copy) == "State Development Index (0-1)"] <- "State Development"


model_after <- lm(`Cancer mortality rate (%)` ~ `State Development` ,data = data_copy)
summary(model_after)

# הצגת ערכי Adjusted R^2 של שני המודלים
adj_r2_before <- summary(model_before)$adj.r.squared
adj_r2_after <- summary(model_after)$adj.r.squared
print(paste("Adjusted R^2 before:", round(adj_r2_before, 4)))
print(paste("Adjusted R^2 after:", round(adj_r2_after, 4)))




#בדיקת האופציה: המרת משתנה רציף "Average Temperature" לקטגוריאלי	

# יצירת גרף פיזור של טמפרטורה ממוצעת מול שיעור תמותה מסרטן
plot(
  dataset$`Average temperature`, 
  dataset$`Cancer mortality rate`,
  main = "Scatter Plot of Average Temperature vs Cancer Mortality Rate",
  xlab = "Average Temperature (°C)",
  ylab = "Cancer Mortality Rate (%)",
  col = "#DA70D6",
  pch = 16      
)

# הוספת קווי רשת לגרף
grid()

#### Q.2.4 ####

library(ggplot2)

#---------------Median age*continent----------------
model_median_age <- lm(dataset$`Cancer mortality rate (%)` ~ dataset$`Median age` * factor(dataset$`Continent`))
summary(model_median_age)

ggplot(dataset, aes(x = `Median age`, y = `Cancer mortality rate (%)`, color = factor(Continent))) +
  geom_point(size = 2, alpha = 0.7) +  # נקודות הנתונים המקוריים
  geom_smooth(method = "lm", se = FALSE, linewidth = 1) +  # קווי מגמה לפי יבשת
  labs(title = "Effect of Median Age on Cancer Mortality Rate by Continent",
       x = "Median Age",
       y = "Cancer Mortality Rate",
       color = "Continent") +
  theme_minimal()

#---------------Smoke*continent----------------
model_smoke <- lm(dataset$'Cancer mortality rate (%)' ~ dataset$'Smoke rate' * factor(dataset$'Continent'))
summary(model_smoke)

ggplot(dataset, aes(x = `Smoke rate`, y = `Cancer mortality rate (%)`, color = factor(Continent))) +
  geom_point(size = 2, alpha = 0.7) +  # נקודות הנתונים המקוריים
  geom_smooth(method = "lm", se = FALSE, linewidth = 1) +  # קווי מגמה לפי יבשת
  labs(title = "Effect of Smoking Rate on Cancer Mortality Rate by Continent",
       x = "Smoking Rate",
       y = "Cancer Mortality Rate",
       color = "Continent") +
  theme_minimal()

#---------------Obesity*continent----------------
model_obesity <- lm(dataset$'Cancer mortality rate (%)' ~ dataset$'Obesity rate' * factor(dataset$'Continent'))
summary(model_obesity)

ggplot(dataset, aes(x = `Obesity rate`, y = `Cancer mortality rate (%)`, color = factor(Continent))) +
  geom_point(size = 2, alpha = 0.7) +  # נקודות הנתונים המקוריים
  geom_smooth(method = "lm", se = FALSE, linewidth = 1) +  # קווי מגמה לפי יבשת
  labs(title = "Effect of Obesity Rate on Cancer Mortality Rate by Continent",
       x = "Obesity Rate",
       y = "Cancer Mortality Rate",
       color = "Continent") +
  theme_minimal()


#---------------full model----------------
full_model <- lm(`Cancer mortality rate (%)` ~ `Obesity rate` +`Smoke rate`  +`State Development` +`Median age`+ `Average temperature` + `Air pollution index` +
                   `Smoke rate` * factor(Continent) +
                   `Obesity rate` * factor(Continent)+
                   `Median age` * factor(Continent),
                 data = dataset)

summary(full_model)



#### Q.3.1 ####

#Empty model
Emp <-  lm (`Cancer mortality rate (%)` ~ 1,data=dataset)
summary(Emp) 

#forward
AIC_forward <- step(Emp, direction = 'forward',scope=formula(full_model))
summary(AIC_forward)

#backward
AIC_backward <- step(full_model, direction = 'backward')
summary(AIC_backward)

#AIC Values
AIC_f <- AIC(AIC_forward)
AIC_b <- AIC(AIC_backward)
print(paste("AIC of Forward Selection:", AIC_f))
print(paste("AIC of Backward Selection:", AIC_b))


#BIC Values
BIC_f <- BIC(AIC_forward)
BIC_b <- BIC(AIC_backward)
print(paste("BIC of Forward Selection:", BIC_f))
print(paste("BIC of Backward Selection:", BIC_b))


if (AIC_f == AIC_b) {
  FinalModel <- AIC_forward  #same models (doesn't matter)
  print("Both Forward and Backward Selection have the same AIC. Using Forward Selection as default.")
} else if (AIC_f < AIC_b) {
  FinalModel <- AIC_forward
  print("Forward Selection is better - AIC smaller")
} else {
  FinalModel <- AIC_backward
  print("Backward Selection is better - AIC smaller")
}

if (BIC_f == BIC_b) {
  FinalModel <- AIC_forward  #same models (doesn't matter)
  print("Both Forward and Backward Selection have the same BIC. Using Forward Selection as default.")
} else if (BIC_f < BIC_b) {
  FinalModel <- AIC_forward
  print("Forward Selection is better - BIC smaller")
} else {
  FinalModel <- AIC_backward
  print("Backward Selection is better - BIC smaller")
}


#final model
summary(FinalModel)

full_aic <- AIC(full_model)
print(paste("AIC of the original full model:", full_aic))
final_aic <- AIC(FinalModel)
print(paste("AIC of the final model:", final_aic))

full_bic <- BIC(full_model)
print(paste("BIC of the original full model:", full_bic))
final_bic <- BIC(FinalModel)
print(paste("BIC of the final model:", final_bic))



#### Q.3.2 ####


# תחזיות מהמודל הסופי
predictions <- predict(FinalModel)

# שגיאות (Residuals) מהמודל הסופי
residuals <- resid(FinalModel)

# שגיאות מנורמלות
std_residuals <- rstandard(FinalModel)

# Plot of Normalized Residuals vs. Predictions
plot(predictions, std_residuals, 
     xlab = "Predicted value", 
     ylab = "Normalized error", 
     main = "Normalized error vs. Predicted value",
     col = "black",        
     pch = 1)               
abline(h = 0, col = "lightblue", lwd = 2)  


# QQ-Plot לבדיקת הנחת הנורמליות
qqnorm(std_residuals, main = "QQ-Plot of Residuals",
       col = "black",  
       pch = 1)        
qqline(std_residuals, col = "lightblue", lwd = 2)  


# היסטוגרמה של השגיאות המנורמלות
hist(std_residuals, 
     breaks = 20,                   
     main = "Histogram of Standardized Residuals", 
     xlab = "Standardized Residuals", 
     col = "lightblue",         # עמודות בצבע תכלת
     border = "black", 
     freq = FALSE)              # צפיפות (Density) במקום שכיחות

# הוספת קו מגמה בצבע שחור
lines(density(std_residuals), 
      col = "black",           # קו בצבע שחור
      lwd = 2) 



#### Q.3.3 ####


# מבחן Kolmogorov-Smirnov
ks.test(std_residuals, y="pnorm", alternative = "two.sided", exact=NULL)

# מבחן Shapiro-Wilk
shapiro.test(std_residuals)

library(strucchange)

#מבחן Chow 
sctest(FinalModel, type= "Chow" )



#### Q.4 ####


library(MASS)

# מבחן Box-Cox
boxcox_result <- boxcox(FinalModel, lambda = seq(-2, 2, by = 0.1))

# מציאת ה-lambda האופטימלי
lambda_optimal <- boxcox_result$x[which.max(boxcox_result$y)]
cat("Optimal lambda:", lambda_optimal)


#בניית מודל חדש לאחר טרנספורמציה על המשתנה המוסבר 
TransformedModel <-lm(formula = log(`Cancer mortality rate (%)`) ~ `State Development` + 
     `Obesity rate` + factor(Continent) + `Air pollution index` + 
     `Obesity rate`:factor(Continent), data = dataset)

summary(TransformedModel)
AIC(TransformedModel)

## בדיקת מבחנים למודל שנוצר ##

std_residualsTrans <- rstandard(TransformedModel)

# מבחן Kolmogorov-Smirnov
ks.test(std_residualsTrans, y="pnorm", alternative = "two.sided", exact=NULL)

# מבחן Shapiro-Wilk
shapiro.test(std_residualsTrans)

library(strucchange)

#מבחן Chow 
sctest(TransformedModel, type= "Chow" )


# החזרת שני המשתנים שהסרנו בסעיפים הקודמים לנתונים
dataset <- cbind (dataset, original_dataset [, c("Depression rate (%)", "Percentage of residents in cities")])


# ניסיון לבצע טרנספורמציות נוספות על המודל מלבד על המשתנה המוסבר
TransformedModelMoreInteraction <- lm(formula = log(`Cancer mortality rate (%)`) ~ `State Development` + 
                                        sqrt(`Obesity rate`) + factor(Continent) + `Air pollution index` + 
                                        `Obesity rate`:factor(Continent),
                                         data = dataset)


summary(TransformedModelMoreInteraction)
AIC(TransformedModelMoreInteraction)


## בדיקת מבחנים למודל שנוצר ##

std_residualsTrans <- rstandard(TransformedModelMoreInteraction)

# מבחן Kolmogorov-Smirnov
ks.test(std_residualsTrans, y="pnorm", alternative = "two.sided", exact=NULL)

# מבחן Shapiro-Wilk
shapiro.test(std_residualsTrans)

library(strucchange)

#מבחן Chow 
sctest(TransformedModelMoreInteraction, type= "Chow" )


plot(dataset$`Obesity rate`, dataset$`Cancer mortality rate (%)`,
     main = "Scatter Plot: Obesity Rate vs Cancer Mortality Rate",
     xlab = "Obesity rate",
     ylab = "Cancer Mortality Rate (%)",
     pch = 19,        # צורת הנקודות
     col = "pink")    # צבע הנקודות







