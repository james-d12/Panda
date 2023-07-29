Select Cast(NA.AccountNumber As Int) as accountNumber
    , NA.AccountName as accountName
    , NA.AccountCostCentre as accountCostCentre
    , CC.Name As costCentreName 
    , NA.AccountDepartment as department
    , D.Name As departmentName
    , AP.PeriodNumber as periodNumber
    , (Case When FY.YearRelativeToCurrentYear = 0 Then SUM(Case When NA.AccountNumber < 3000 Or NA.AccountNumber >= 6950
          Then APV.ActualValue * -1
          Else APV.ActualValue
      End) Else 0 End) as actualValue
	  , (Case When FY.YearRelativeToCurrentYear = 0 Then SUM(Case When NA.AccountNumber < 3000 Or NA.AccountNumber >= 6950 
          Then APV.BudgetValue * -1
          Else APV.BudgetValue
      End) Else 0 End) as budgetValue
	, (Case When FY.YearRelativeToCurrentYear = -1 Then SUM(Case When NA.AccountNumber < 3000 Or NA.AccountNumber >= 6950 
          Then APV.BudgetValue * -1
          Else APV.BudgetValue
      End) Else 0 End) as budgetValuePrevious
    From [ScottBrownriggConsolidated].[dbo].NLAccountPeriodValue APV
    Left Join [ScottBrownriggConsolidated].[dbo].SYSAccountingPeriod AP On AP.SYSAccountingPeriodID = APV.SYSAccountingPeriodID
    Left Join [ScottBrownriggConsolidated].[dbo].NLNominalAccount NA On NA.NLNominalAccountID = APV.NLNominalAccountID
    Left Join [ScottBrownriggConsolidated].[dbo].NLCostCentre CC On CC.NLCostCentreID = NA.NLCostCentreID
    Left Join [ScottBrownriggConsolidated].[dbo].NLDepartment D On D.NLDepartmentID = NA.NLDepartmentID
    Left Join [ScottBrownriggConsolidated].[dbo].SYSFinancialYear FY On FY.SYSFinancialYearID = AP.SYSFinancialYearID
    Join [ScottBrownriggConsolidated].[dbo].SYSAccountingPeriod CurAP On EOMonth(Getdate(), -1) Between CurAP.StartDate And CurAP.EndDate
    Where FY.YearRelativeToCurrentYear In (0, -1) 
    And NA.AccountNumber Not Like '0%' 
    Group By NA.AccountCostCentre
        , NA.AccountNumber
        , NA.AccountDepartment
        , NA.AccountName
        , CC.Name
        , D.Name
        , AP.StartDate
        , AP.PeriodNumber
    	, FY.YearRelativeToCurrentYear
    Having SUM(APV.ActualValue) <> 0
        Or SUM(APV.BudgetValue) <> 0
    Order By NA.AccountNumber
