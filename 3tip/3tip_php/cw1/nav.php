<?php
function ShowNav() {
echo <<<html
 <nav class="navbar">
            <ul>
                <li>
                    <a href="cw1.php">Główna</a>
                </li>
                <li>
                    <a href="list.php">Lista kontaktów</a>
                </li>
                <li>
                    <a href="add_contact.php">Dodaj kontakt</a>
                </li>
            </ul>
        </nav>
html;
}
function ShowFooter() {
 echo <<< html
<footer>
        &copy;2026 Wykonał Aleksy XXXXXXXXX
    </footer>

    <script src="cw1.js"></script>
html;
}
