using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI.Localization;

namespace Landlord
{
    public class MyChsRadGridLocalizationProvider : RadGridLocalizationProvider
{
   public override string GetLocalizedString(string id)
   {
       switch (id)
       {
           case RadGridStringId.FilterFunctionBetween: return "介于";
           case RadGridStringId.FilterFunctionContains: return "包含";
           case RadGridStringId.FilterFunctionDoesNotContain: return "不包含";
           case RadGridStringId.FilterFunctionEndsWith: return "结尾于";
           case RadGridStringId.FilterFunctionEqualTo: return "等于";
           case RadGridStringId.FilterFunctionGreaterThan: return "大于";
           case RadGridStringId.FilterFunctionGreaterThanOrEqualTo: return "大于等于";
           case RadGridStringId.FilterFunctionIsEmpty: return "为空";
           case RadGridStringId.FilterFunctionIsNull: return "为Null";
           case RadGridStringId.FilterFunctionLessThan: return "小于";
           case RadGridStringId.FilterFunctionLessThanOrEqualTo: return "小于等于";
           case RadGridStringId.FilterFunctionNoFilter: return "无过滤";
           case RadGridStringId.FilterFunctionNotBetween: return "不介于";
           case RadGridStringId.FilterFunctionNotEqualTo: return "不等于";
           case RadGridStringId.FilterFunctionNotIsEmpty: return "不为空";
           case RadGridStringId.FilterFunctionNotIsNull: return "不为Null";
           case RadGridStringId.FilterFunctionStartsWith: return "开始于";
           case RadGridStringId.FilterFunctionCustom: return "自定义";
           case RadGridStringId.CustomFilterMenuItem: return "菜单项";
           case RadGridStringId.CustomFilterDialogCaption: return "对话框标题";
           case RadGridStringId.CustomFilterDialogLabel: return "对话框文本";
           case RadGridStringId.CustomFilterDialogRbAnd: return "与";
           case RadGridStringId.CustomFilterDialogRbOr: return "或";
           case RadGridStringId.CustomFilterDialogBtnOk: return "确定";
           case RadGridStringId.CustomFilterDialogBtnCancel: return "取消";
           case RadGridStringId.DeleteRowMenuItem: return "删除";
           case RadGridStringId.SortAscendingMenuItem: return "升序排序";
           case RadGridStringId.SortDescendingMenuItem: return "降序排序";
           case RadGridStringId.ClearSortingMenuItem: return "清除排序";
           case RadGridStringId.ConditionalFormattingMenuItem: return "条件格式化";
           case RadGridStringId.GroupByThisColumnMenuItem: return "按此列分组";
           case RadGridStringId.UngroupThisColumn: return "取消此列分组";
           case RadGridStringId.ColumnChooserMenuItem: return "列选择";
           case RadGridStringId.HideMenuItem: return "隐藏";
           case RadGridStringId.UnpinMenuItem: return "取消锁定";
           case RadGridStringId.PinMenuItem: return "锁定";
           case RadGridStringId.BestFitMenuItem: return "合适尺寸";
           case RadGridStringId.PasteMenuItem: return "粘贴";
           case RadGridStringId.EditMenuItem: return "编辑";
           case RadGridStringId.CopyMenuItem: return "复制";
           case RadGridStringId.AddNewRowString: return "增加新行";
//           case RadGridStringId.ConditionalFormattingCaption: return "条件格式化标题";
//           case RadGridStringId.ConditionalFormattingLblColumn: return "条件格式化列:";
//           case RadGridStringId.ConditionalFormattingLblName: return "条件格式化列名:";
//           case RadGridStringId.ConditionalFormattingLblType: return "条件格式化列类型:";
//           case RadGridStringId.ConditionalFormattingLblValue1: return "条件格式化值1:";
//           case RadGridStringId.ConditionalFormattingLblValue2: return "条件格式化值2:";
//           case RadGridStringId.ConditionalFormattingGrpConditions: return "Auflagen";
//           case RadGridStringId.ConditionalFormattingGrpProperties: return "Eigenschaften";
//           case RadGridStringId.ConditionalFormattingChkApplyToRow: return "Auf Zeile anwenden";
//           case RadGridStringId.ConditionalFormattingBtnAdd: return "Ansetzen";
//           case RadGridStringId.ConditionalFormattingBtnRemove: return "Lö;
//           case RadGridStringId.ConditionalFormattingBtnOK: return "OK";
//           case RadGridStringId.ConditionalFormattingBtnCancel: return "Annullieren";
//           case RadGridStringId.ConditionalFormattingBtnApply: return "Anlegen";
//           case RadGridStringId.ColumnChooserFormCaption: return "Spalte Waehlende";
//           case RadGridStringId.ColumnChooserFormMessage: return @"Eine Spalte um zu verstecken,\n     
//                   stellen Sie sie vom RadGridView in diesem Fenster";
           default:
               return base.GetLocalizedString(id);
       }
   }
}
}
