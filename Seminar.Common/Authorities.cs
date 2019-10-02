using System;

namespace Seminar.Common
{

    /// <summary>
    /// Authorities in System
    /// </summary>
    [Flags]
    public enum Authorities
    {
        NormalUser = 0,
        /// <summary>
        /// 拠 点 管 理 者
        /// </summary>
        SchoolManager = 1,

        /// <summary>
        /// セ ミ ナー 管 理
        /// </summary>
        SeminarManager = 1 << 1,

        /// <summary>
        /// 商 品 管 理
        /// </summary>
        ProductManager = 1 << 2,

        /// <summary>
        /// シ ス テ ム 管 理
        /// </summary>
        SystemManager = 1 << 3
    }
}
