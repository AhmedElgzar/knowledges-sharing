module Main where

main = putStrLn $ show $ exchange 4 [2,1]

exchange:: Integer -> [Integer] -> Integer
exchange 0 _ = 1
exchange _ [] = 0
exchange amount coins
	| amount < 0 = 0
	| otherwise = exchange (amount - head coins) coins + exchange amount (tail coins)