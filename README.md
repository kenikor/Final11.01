import androidx.compose.foundation.layout.*
import androidx.compose.foundation.text.BasicTextField
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun LoginScreen() {
    var username by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var message by remember { mutableStateOf("") }

    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Center
    ) {
        // Поле ввода логина
        TextField(
            value = username,
            onValueChange = { username = it },
            label = { Text("Логин") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        // Поле ввода пароля
        TextField(
            value = password,
            onValueChange = { password = it },
            label = { Text("Пароль") },
            visualTransformation = PasswordVisualTransformation(),
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(16.dp))

        // Кнопка "Авторизоваться"
        Button(
            onClick = { message = "$username, вы авторизованы" },
            shape = MaterialTheme.shapes.medium,
            modifier = Modifier.fillMaxWidth()
        ) {
            Text("Авторизоваться")
        }

        Spacer(modifier = Modifier.height(16.dp))

        // Сообщение об авторизации
        Text(text = message, fontSize = 18.sp)

        Spacer(modifier = Modifier.height(16.dp))

        // Сравнение внешнего вида кнопок
        OutlinedButton(onClick = { /* Действие для OutlinedButton */ }) {
            Text("OutlinedButton")
        }

        Spacer(modifier = Modifier.height(8.dp))

        TextButton(onClick = { /* Действие для TextButton */ }) {
            Text("TextButton")
        }
    }
}
