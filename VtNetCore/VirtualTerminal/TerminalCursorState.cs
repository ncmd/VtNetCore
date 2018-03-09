﻿namespace VtNetCore.VirtualTerminal
{
    using System.Collections.Generic;
    using System.Linq;
    using VtNetCore.VirtualTerminal.Enums;
    using VtNetCore.VirtualTerminal.Model;

    /// <summary>
    /// The current cursor state as known by the controller
    /// </summary>
    public class TerminalCursorState
    {
        /// <summary>
        ///  The current column of the cursor.
        /// </summary>
        public int CurrentColumn { get; set; } = 0;

        /// <summary>
        /// The current row of the cursor relative to the top of the visible screen, not the buffer.
        /// </summary>
        public int CurrentRow { get; set; } = 0;

        /// <summary>
        /// Set to true when in application mode
        /// </summary>
        public bool ApplicationCursorKeysMode { get; set; } = false;

        /// <summary>
        /// The current drawing attribute for text.
        /// </summary>
        public TerminalAttribute Attributes { get; set; } = new TerminalAttribute();

        /// <summary>
        /// Specifies whether to show the text cursor
        /// </summary>
        public bool ShowCursor { get; set; } = true;

        /// <summary>
        /// Specifies whether the text cursor should be blinking
        /// </summary>
        public bool BlinkingCursor { get; set; } = true;

        /// <summary>
        /// Defines the shape of the cursor
        /// </summary>
        public ECursorShape CursorShape { get; set; } = ECursorShape.Block;

        /// <summary>
        /// The currently configured tab stops (in base 1)
        /// </summary>
        public List<int> TabStops = new List<int>
        {
            0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80
        };

        /// <summary>
        /// Specifies true if automatic word wrap should be employed.
        /// </summary>
        public bool WordWrap = true;

        /// <summary>
        /// Set to true if the entire screen should invert foreground and background colors
        /// </summary>
        public bool ReverseVideoMode = false;

        /// <summary>
        /// Specifies the top line of the current scrolling region in terms of screen coordinates
        /// </summary>
        public int ScrollTop = 0;

        /// <summary>
        /// Specifies the bottom line of the current scrolling region in terms of screen coordinates
        /// </summary>
        /// <remarks>
        /// If this value is -1, then the bottom of the visible screen should be assumed.
        /// </remarks>
        public int ScrollBottom = -1;

        /// <summary>
        /// Specifies whether the coordinate system is relative to the currently configured scrolling region
        /// </summary>
        public bool OriginMode = false;

        /// <summary>
        /// Specifies whether the terminal should auto insert or replace text on the screen.
        /// </summary>
        public EInsertReplaceMode InsertMode = EInsertReplaceMode.Replace;

        /// <summary>
        /// When left and right margins are enabled, specifies the left margin
        /// </summary>
        public int LeftMargin { get; set; }

        /// <summary>
        /// When left and right margins are enabled, specifies the left margin
        /// </summary>
        public int RightMargin { get; set; }

        /// <summary>
        /// Configures that left and right margins should be used
        /// </summary>
        public bool LeftAndRightMarginEnabled { get; set; }

        /// <summary>
        /// Flags whether the current character set is meant to be read as Utf8
        /// </summary>
        public bool Utf8 { get; set; } = true;

        /// <summary>
        /// Specifies the active character mode for the L region
        /// </summary>
        public ECharacterSetMode CharacterSetMode { get; set; } = ECharacterSetMode.IsoG0;

        /// <summary>
        /// Specifies the active character mode for the R region
        /// </summary>
        public ECharacterSetMode CharacterSetModeR { get; set; } = ECharacterSetMode.IsoG0;

        /// <summary>
        /// The configured character set for the G0 page
        /// </summary>
        public ECharacterSet G0 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// The configured character set for the G1 page
        /// </summary>
        public ECharacterSet G1 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// The configured character set for the G2 page
        /// </summary>
        public ECharacterSet G2 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// The configured character set for the G3 page
        /// </summary>
        public ECharacterSet G3 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// The configured character set for the Vt300 G1 page
        /// </summary>
        public ECharacterSet Vt300G1 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// The configured character set for the Vt300 G2 page
        /// </summary>
        public ECharacterSet Vt300G2 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// The configured character set for the Vt300 G3 page
        /// </summary>
        public ECharacterSet Vt300G3 { get; set; } = ECharacterSet.USASCII;

        /// <summary>
        /// Specifies whether LF should assume CR
        /// </summary>
        public bool AutomaticNewLine { get; set; }

        /// <summary>
        /// The number of columns configured by the server
        /// </summary>
        public int ConfiguredColumns { get; set; }

        /// <summary>
        /// Deep copy
        /// </summary>
        /// <returns>A deep copy of the state</returns>
        public TerminalCursorState Clone()
        {
            return new TerminalCursorState
            {
                CurrentColumn = CurrentColumn,
                CurrentRow = CurrentRow,
                ApplicationCursorKeysMode = ApplicationCursorKeysMode,
                Attributes = Attributes.Clone(),
                TabStops = TabStops.ToList(),
                WordWrap = WordWrap,
                ReverseVideoMode = ReverseVideoMode,
                ScrollTop = ScrollTop,
                ScrollBottom = ScrollBottom,
                OriginMode = OriginMode,
                InsertMode = InsertMode,
                ShowCursor = ShowCursor,
                BlinkingCursor = BlinkingCursor,
                CursorShape = CursorShape,
                LeftAndRightMarginEnabled = LeftAndRightMarginEnabled,
                LeftMargin = LeftMargin,
                RightMargin = RightMargin,
                Utf8 = Utf8,
                CharacterSetMode = CharacterSetMode,
                G0 = G0,
                G1 = G1,
                G2 = G2,
                G3 = G3,
                Vt300G1 = Vt300G1,
                Vt300G2 = Vt300G2,
                Vt300G3 = Vt300G3,
                AutomaticNewLine = AutomaticNewLine,
                ConfiguredColumns = ConfiguredColumns
            };
        }

        /// <summary>
        /// Creates a debug string for spamming the display with too much information
        /// </summary>
        /// <returns>A formatted debug string</returns>
        public override string ToString()
        {
            return
                "CurrentColumn: " + CurrentColumn.ToString() + "\n" +
                "CurrentRow:" + CurrentRow.ToString() + "\n" +
                "ApplicationCursorKeysMode:" + ApplicationCursorKeysMode.ToString() + "\n" +
                "Attribute:\n" + Attributes.ToString() + "\n" +
                "TabStops:" + string.Join(",", TabStops.Select(x => x.ToString()).ToList()) + "\n" +
                "WordWrap:" + WordWrap.ToString() + "\n" +
                "ReverseVideoMode:" + ReverseVideoMode.ToString() + "\n" +
                "ScrollTop:" + ScrollTop.ToString() + "\n" +
                "ScrollBottom:" + ScrollBottom.ToString() + "\n" +
                "OriginMode:" + OriginMode.ToString() + "\n" +
                "InsertMode:" + InsertMode.ToString() + "\n" +
                "ShowCursor:" + ShowCursor.ToString() + "\n" +
                "BlinkingCursor:" + BlinkingCursor.ToString() + "\n" +
                "CursorShape:" + CursorShape.ToString() + "\n" + 
                "LeftAndRightMarginEnabled:" + LeftAndRightMarginEnabled.ToString() + "\n" +
                "LeftMargin:" + LeftMargin.ToString() + "\n" +
                "RightMargin:" + RightMargin.ToString() + "\n" +
                "Utf8:" + Utf8.ToString() + "\n" +
                "CharacterSetMode:" + CharacterSetMode.ToString() + "\n" +
                "G0:" + G0.ToString() + "\n" +
                "G1:" + G1.ToString() + "\n" +
                "G2:" + G2.ToString() + "\n" +
                "G3:" + G3.ToString() + "\n" +
                "Vt300G1:" + Vt300G1.ToString() + "\n" +
                "Vt300G2:" + Vt300G2.ToString() + "\n" +
                "Vt300G3:" + Vt300G3.ToString() + "\n" +
                "AutomaticNewLine:" + AutomaticNewLine.ToString() + "\n" +
                "ConfiguredColumns:" + ConfiguredColumns.ToString() + "\n"
                ;
        }
    }
}