# Jpmorgan-Trifon
jpmorgan.SuperSimpleStocks

Requirements
1. The Global Beverage Corporation Exchange is a new stock market trading in drinks companies.
a. Your company is building the object-oriented system to run that trading.
b. You have been assigned to build part of the core object model for a limited phase 1
2. Provide the complete source code that will:-
a. For a given stock,
i. Given any price as input, calculate the dividend yield
ii. Given any price as input, calculate the P/E Ratio
iii. Record a trade, with timestamp, quantity, buy or sell indicator and price
iv. Calculate Volume Weighted Stock Price based on trades in past 5 minutes
b. Calculate the GBCE All Share Index using the geometric mean of the Volume Weighted Stock Price for all stocks
Constraints & Notes
1. Written in one of these languages - Java, C#, C++, Python
2. The source code should be suitable for forming part of the object model of a production application, and can be proven to meet the requirements. A shell script is not an appropriate submission for this assignment.
3. No database, GUI or I/O is required, all data need only be held in memory
4. No prior knowledge of stock markets or trading is required – all formulas are provided below.
5. The code should provide only the functionality requested, however it must be production quality.
Table1. Sample data from the Global Beverage Corporation Exchange
Stock Symbol 	Type 		Last Dividend 	Fixed Dividend 	Par Value
TEA		        Common		 0			                      100		
POP		        Common		 8                     				100
ALE		        Common		23				                     60
GIN		        Preferred	 8          		2%        		100
JOE		        Common		13                    				250

Formulas:
(Common)  Dividend Yield = 𝐿𝑎𝑠𝑡 𝐷𝑖𝑣𝑖𝑑𝑒𝑛𝑑 / Price
(Preferred) Dividend Yield = 𝐹𝑖𝑥𝑒𝑑 𝐷𝑖𝑣𝑖𝑑𝑒𝑛𝑑 .𝑃𝑎𝑟 𝑉𝑎𝑙𝑢𝑒 / Price
P/E Ratio = 𝑃𝑟𝑖𝑐𝑒 / 𝐷𝑖𝑣𝑖𝑑𝑒𝑛𝑑
 Geometric Mean = nth root of the product of n numbers
 Volume Weighted Stock Price = Σi 𝑇𝑟𝑎𝑑𝑒𝑑 𝑃𝑟𝑖𝑐𝑒𝑖×𝑄𝑢𝑎𝑛𝑡𝑖𝑡𝑦𝑖 / Σi𝑄𝑢𝑎𝑛𝑡𝑖𝑡𝑦𝑖
