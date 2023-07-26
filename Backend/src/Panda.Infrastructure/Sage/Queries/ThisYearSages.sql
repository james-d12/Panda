Select Cast(NA.AccountNumber As Int) As accountNumber 
     , NA.AccountName As accountName
     , NA.AccountCostCentre As accountCostCentre
	 , CC.Name As costCentreName
	 , NA.AccountDepartment as department
	 , D.Name As departmentName
     , Case When Max(CurAP.StartDate) < Max(FY.FinancialYearStartDate)
            Then 0
            Else
                 Sum(Case When AP.StartDate < CurAP.StartDate Then Case When NA.AccountNumber < 3000 Or NA.AccountNumber >= 6950
                                                                        Then APV.ActualValue * -1
                                                                        Else APV.ActualValue
                                                                    End
                          Else 0
                      End)
                 / Case When Max(CurAP.StartDate) Between Max(FY.FinancialYearStartDate) And EOMonth(Max(FY.FinancialYearStartDate), Max(FY.NumberOfPeriodsInYear))
                        Then Max(CurAP.PeriodNumber)
                        Else Max(FY.NumberOfPeriodsInYear)
                    End
                 * Max(FY.NumberOfPeriodsInYear)
       End As runRate
     , SUM(Case When NA.AccountNumber < 3000 Or NA.AccountNumber >= 6950
                Then APV.BudgetValue * -1
                Else APV.BudgetValue
            End) budgetValue
    From [ScottBrownriggConsolidated].[dbo].NLAccountPeriodValue APV
    Join [ScottBrownriggConsolidated].[dbo].SYSAccountingPeriod AP On AP.SYSAccountingPeriodID = APV.SYSAccountingPeriodID
    Left Join [ScottBrownriggConsolidated].[dbo].NLNominalAccount NA On NA.NLNominalAccountID = APV.NLNominalAccountID
    Left Join [ScottBrownriggConsolidated].[dbo].NLCostCentre CC On CC.NLCostCentreID = NA.NLCostCentreID
    Left Join [ScottBrownriggConsolidated].[dbo].NLDepartment D On D.NLDepartmentID = NA.NLDepartmentID
    Join [ScottBrownriggConsolidated].[dbo].SYSFinancialYear FY On FY.SYSFinancialYearID = AP.SYSFinancialYearID
    Join [ScottBrownriggConsolidated].[dbo].SYSAccountingPeriod CurAP On EOMonth(Getdate(), -1) Between CurAP.StartDate And CurAP.EndDate
    Where FY.YearRelativeToCurrentYear = 0
        And NA.AccountNumber NOT Like '0%'
    Group By NA.AccountCostCentre
     , NA.AccountNumber
     , NA.AccountDepartment
     , NA.AccountName
     , CC.Name
     , D.Name
     , Format(FY.FinancialYearStartDate,'yyyy')
    Having SUM(APV.ActualValue) <> 0
        Or SUM(APV.BudgetValue) <> 0
    Order By NA.AccountNumber
     , NA.AccountCostCentre
     , NA.AccountDepartment